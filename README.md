Caro leitor: antes de começar a ler este texto, clique no botão 'RAW' para a formatação aparecer corretamente. Obrigado

Projeto Clima Tempo Simples

Pré-requisitos de instalação para rodar aplicação localmente
 - Visual Studio 2017 ou posterior com .Net Framework 4.7.2
 - Sql Server Express 2014 ou posterior
 - Git
 - Opcional: Sql Management Studio
 
Instalação e execução da aplicação
 1 - Baixar uma cópia da solução
    - Clicar no notão 'Download ZIP' ou
    - Via linha de comando através da instrução a seguir:
      gh repo clone cristianomartinsdias82/ClimaTempoSimples
 2 - Abrir a solução ClimaTempoSimples pelo Visual Studio
     NOTA: se a solução foi baixada via zip, descompacte a solução em alguma pasta de sua preferência e navegue até ela
 3 - Na janela Solution Explorer:
     3.1 - Expandir a pasta docs
     3.2 - Copiar o conteúdo contido no arquivo "sistema_consulta_clima.sql"
 3 - Abrir um aplicativo que permite conectar ao banco de dados (Sql Management Studio, por exemplo) e abrir uma nova janela de consulta (CTRL+N permite fazer isto)
 4 - Colar o conteúdo do passo 3.1  nesta janela
 5 - Rodar todo o script existente na janela (Tecla F5)
 5 - Na janela Solution Explorer, expandir o projeto ClimaTempoSimples (na pasta src/presentation)
 6 - Localizar o arquivo web.config na raiz do projeto
     6.1 Localizar a seção connection strings e alterar a string de conexão com banco o banco de dados, localizando o trecho:
         ...data source=.;initial catalog=ClimaTempoSimples;integrated security=True;...
        
        e substituindo pela string de conexão conforme a configuração do banco na máquina.
        NOTA: se o banco estiver na própria máquina + o nome do banco de dados é ClimaTempoSimples + a autenticação do banco de dados for integrada, não é necessário realizar este passo!
 7 - Compilar e rodar a aplicação (CTRL + F5)
