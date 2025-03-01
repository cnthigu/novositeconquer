# Conquer Online - Website em ASP.NET

&#x20;

## Sobre o Projeto

Este projeto é o desenvolvimento de um website para um servidor do jogo **Conquer Online**, originalmente escrito em PHP e refatorado para **ASP.NET** com **C#**, **HTML** e **CSS**. O objetivo principal foi modernizar a aplicação, aumentar a segurança, melhorar a escalabilidade e implementar boas práticas de desenvolvimento, como prevenção de vulnerabilidades (**ex.: SQL Injection**). O sistema inclui integração com uma API de pagamento e um módulo de recuperação de e-mails, demonstrando habilidades em **backend**, **frontend** e **integração de serviços externos**.

---

## Funcionalidades Principais

✅ **Refatoração do Site**: Transição de PHP para ASP.NET, com melhoria no desempenho e manutenção.

✅ **Segurança Avançada**: Implementação de práticas para prevenir **SQL Injection** e proteger dados sensíveis.

✅ **Sistema de Pagamento**: Integração com a **API Asaas** para processamento de transações.

✅ **Recuperação de E-mails**: Funcionalidade para suporte ao usuário no gerenciamento de contas.

✅ **Banco de Dados**: Uso do **MySQL Server** para armazenamento eficiente e escalável.

---

## Tecnologias Utilizadas

- **ASP.NET**: Framework principal para o backend.
- **C#**: Linguagem de programação para lógica de negócios e controle.
- **HTML/CSS**: Estruturação e estilização do frontend.
- **MySQL**: Banco de dados relacional para persistência de dados.
- **Asaas API**: Integração de sistema de pagamento online.

---

## Demonstrações do Projeto

Para uma visão prática da implementação e evolução do projeto, confira os vídeos demonstrativos abaixo:

📌 **Versão 1.0.0** - [Vídeo Demonstrativo](https://youtu.be/4mmKo8R8_hk)&#x20;

📌 **Versão 3.0.0** - [Vídeo Demonstrativo](https://youtu.be/WTzRSfK23CA)&#x20;

📌 **Versão 4.0.0** - [Vídeo Demonstrativo](https://youtu.be/72jCJgFOeQk)&#x20;

---

## Como Executar o Projeto

### 📌 Pré-requisitos

- .NET Framework instalado (**versão compatível com o projeto**).
- MySQL Server configurado e em execução.
- Visual Studio (**recomendado para desenvolvimento e debugging**).
- Acesso à API Asaas (**chave de integração necessária para pagamentos**).

### ⚙️ Passos para Configuração

1. **Clone o Repositório**

   ```sh
   git clone https://github.com/cnthigu/novositeconquer.git
   cd seurepositorio
   ```

2. **Configuração do Banco de Dados**

   - Crie um banco de dados MySQL.
   - Importe o esquema necessário (**disponível no repositório** ou gerado via migrations, se aplicável).
   - Atualize as credenciais de conexão no arquivo `appsettings.json` ou na configuração do projeto no Visual Studio.

3. **Instale as Dependências**

   - Abra o projeto no Visual Studio.
   - Restaure os pacotes NuGet, se necessário.

4. **Executando o Projeto**

   - Compile e execute o projeto diretamente pelo Visual Studio.
   - Ou via linha de comando:
     ```sh
     dotnet run
     ```
   - Certifique-se de que a **API Asaas** esteja configurada com uma chave válida para testes de pagamento.

---

## 🏗️ Estrutura do Projeto

📂 **Controllers/** → Lógica de roteamento e controle da aplicação.

📂 **Models/** → Definições de entidades e regras de negócio.

📂 **Views/** → Páginas renderizadas com **HTML e CSS**.

📂 **Services/** → Camada de integração com a **API Asaas** e operações de e-mail.

---

## 🎯 Habilidades Demonstradas

🚀 Desenvolvimento **full-stack** com **ASP.NET, C#, HTML e CSS**.

🔗 Integração de **APIs externas** (ex.: **Asaas** para pagamentos).

🔐 **Boas práticas de segurança** em aplicações web.

🗄️ **Gerenciamento de banco de dados relacional** (**MySQL**).

♻️ **Refatoração de código legado** para tecnologias modernas.

---

## 📞 Contato

Se precisar de mais informações ou quiser discutir o projeto, entre em contato comigo:

📧 **E-mail:** [higorzen77](mailto\:higorzen77@gmail.com)

🐙 **GitHub:** [github.com/cnthigu](https://github.com/cnthigu)

🔗 **LinkedIn:** [linkedin.com/in/higor-cnt-viniciusl](www.linkedin.com/in/higor-cnt-vinicius)

---

🔹 **Gostou do projeto?** Considere deixar uma ⭐ para apoiar o desenvolvimento!

