# Task Manager API

API simples para gerenciamento de tarefas, desenvolvida em C# com .NET.

## 🚀 Funcionalidades

A API permite:

- ✅ Criar uma tarefa
- ✅ Deletar uma tarefa por ID
- ✅ Listar todas as tarefas
- ✅ Buscar uma tarefa por ID
- ✅ Atualizar uma tarefa por ID

---

## 📦 Tecnologias utilizadas

- C#
- .NET
- ASP.NET Core

---

## ▶️ Como executar o projeto

### 1. Clone o repositório

```bash
git clone <url-do-repositorio>
```

### 2. Acesse a pasta do projeto

```bash
cd nome-do-projeto
```

### 3. Abra o projeto no VS Code

```bash
code .
```

### 4. Execute a aplicação

```bash
dotnet run --launch-profile https
```

A API estará disponível após a inicialização.

---

## 🗄️ Banco de dados

Este projeto utiliza armazenamento local em um arquivo JSON para persistência dos dados.

Os dados são salvos diretamente dentro do projeto, sem necessidade de configurar um banco de dados externo.

---

## 📌 Endpoints disponíveis

| Método | Endpoint      | Descrição            |
| ------ | ------------- | -------------------- |
| POST   | `/tasks`      | Criar tarefa         |
| GET    | `/tasks`      | Listar tarefas       |
| GET    | `/tasks/{id}` | Buscar tarefa por ID |
| PUT    | `/tasks/{id}` | Atualizar tarefa     |
| DELETE | `/tasks/{id}` | Remover tarefa       |

---

## 📄 Licença

Este projeto está disponível para fins de estudo e aprendizado.
