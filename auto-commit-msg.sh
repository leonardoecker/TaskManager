#!/bin/bash

if ! git rev-parse --is-inside-work-tree >/dev/null 2>&1; then
    echo "Erro: não é um repositório git"
    exit 1
fi

if [ -z "$GEMINI_API_KEY" ]; then
    echo "Erro: GEMINI_API_KEY não configurada"
    exit 1
fi

if git diff --quiet && git diff --cached --quiet; then
    echo "Nenhuma alteração encontrada"
    exit 0
fi

echo "Coletando alterações..."

git add .

# Limita tamanho do diff para evitar payloads gigantes
DIFF=$(git diff --cached | head -c 100000)

PROMPT=$(cat <<EOF
Analise as alterações abaixo.

Gere uma mensagem de commit seguindo Conventional Commits.

Regras:
- Formato: tipo(escopo): descrição
- Tipos: feat, fix, refactor, docs, style, test, chore
- Máximo 72 caracteres
- Retorne apenas a mensagem
- Não adicione markdown
- Não adicione explicações

Mudanças:
$DIFF
EOF
)

echo "Gerando commit..."

RESPONSE=$(curl -s \
-H "x-goog-api-key: $GEMINI_API_KEY" \
-H "Content-Type: application/json" \
-X POST \
"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent" \
-d "$(jq -n \
--arg prompt "$PROMPT" \
'{
  contents: [
    {
      parts: [
        {
          text: $prompt
        }
      ]
    }
  ]
}')")

COMMIT_MSG=$(echo "$RESPONSE" | jq -r '.candidates[0].content.parts[0].text // empty')

if [ -z "$COMMIT_MSG" ]; then
    echo ""
    echo "Erro ao gerar mensagem."
    echo ""
    echo "$RESPONSE"
    exit 1
fi

# remove quebras de linha e espaços extras
COMMIT_MSG=$(echo "$COMMIT_MSG" | tr -d '\n' | xargs)

echo ""
echo "Sugestão:"
echo "$COMMIT_MSG"
echo ""

read -p "Deseja realizar commit? (y/n): " CONFIRM

if [[ "$CONFIRM" =~ ^[Yy]$ ]]; then
    git commit -m "$COMMIT_MSG"
    echo "Commit realizado"
else
    echo "Cancelado"
fi