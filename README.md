# LTM
Código referente ao teste para vaga de Desenvolvedor no Grupo LTM


Módulos:

  - API
    - Entity Framework Core
    - Configurável para utilizar contexto SQL Server ou MongoDB
    - Mapper para fazer conversão entre objetos, expondo apenas dados realmente necessários
    - Autenticação via JWT
    - Tempo expiração do token JWT configurado para 1 minuto
    - Utilizado Swagger para melhor visualização dos métodos disponíveis
    - Os métodos de Login e Cadastro de Usuários podem ser utilizados sem necessidade de autenticação, porém para os outros é necessário envio de token recebido no momento de login
   
   
  - WEB
    - Utilizado telas em Razor
    - Tela básica com as funções:
        - Efetuar login
        - Cadastro de usuário
        - Lista de produtos
        - Cadastro de produto
    - Ao expirar o token JWT é exibido alerta para efetuar novo login
    
    
  - Repositórios
    - Criei interface para os repositórios, para que assim possa implementar o mesmo padrão de utilizando Mongo ou SQL
    - Criei uma classe abstrata para Entity e outra para Mongo, assim posso ter repositórios que implementam a mesma interface, porém recebendo contextos diferentes (Mongo ou SQL)
    - Para cada tecnologia de base, criei um mapeamento das classes para a base, assim escolhendo o padrão para base de dados
    
  
  - Entidades
    - Criei entidades com fins diferentes, as Entity.DAL e Entity.API para que não sejam trafegados informações desnecessárias
    - Entity.DAL é o mapeamento do banco para a aplicação
    - Entity.API são as classes utilizadas para trafegar informações entre o projeto Web e API
    - Uma vantagem de ter uma classe para comunicação entre a API e Web, é que posso reutilizar a classe
    
    
  - Base de dados
    - Ao utilizar MongoDB, a estrutura é criada automaticamente
    - Para SQL, inseri um arquivo com o script de criação da base
    - Não criei script de carga, visto que os dados podem ser criados via tela ou serviço
