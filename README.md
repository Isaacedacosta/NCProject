# NCProject
Importar o arquivo Location.xls to the SQLServer (instruções abaixo)

Abrir o arquivo DbServices.CS
Localizado em 2) Application > NCProjectApplication > Services
Alterar a string connectionString para encontrar o banco onde foi importado a dbo.Locations

Pronto! Pode executar o app.


(instruções para importar o arquivo de excel para dentro do banco de dados SQL)
Selecionar o banco dentro do MicrosoftSqlServer
Tarefas > Importar Dados
Selecionar como fonte de dados "microsoft excel"
Localizar o arquivo dos dados
Manter ativo "A primeira linha possui nomes de colunas"
Selecionar o banco que ira receber os dados
Selecionar 'Locations'
Concluir a importação


