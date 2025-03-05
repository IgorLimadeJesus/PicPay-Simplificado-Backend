
# Introdução
O projeto em si trate de se de um desafio técnico do PicPay, eu fui e me desafiei a fazer esse desafio para estudar.

*****
## O que é o projeto?

O projeto é uma API, onde simula as Carteiras do PicPay e as transferências entre elas. Nele contem:

 * **Criar uma carteira:** Você consegue criar uma carteira e tem a opção de escolher se será do tipo **Lojista** ou **Usuário**, levando em conta que carteiras do tipo lojistas poderão apenas receber e não enviar, já do tipo usuário poderá receber e enviar.
 
 * **Criar uma Transação:** Você poderá criar uma transação onde enviara um determinado valor para outra carteira. essas Transações são armazenadas em um banco de dados SQL, e poderá ser puxada quando quiser.
 
 * **Consultar uma carteira especifica:** Você poderá consultar uma carteira especifica pelo id dela. Lembre-se, caso o id não existir, ele irá retornar um erro dizendo que a carteira não existe.
 
 * **Consultar transações**: Você também poderá consultar as transações, vc poderá listar todas as transações, ou listar uma em especifica pelo Id, tbm será **possível** deletar transações(caso for deletada, o valor enviado não irá retornar ao remetente, você apenas irá deletar ela do banco de dados).

*****

## Endpoints

#### Carteiras

~~~~
Post: https://localhost:porta/api/Carteira
Get{id}: https://localhost:porta/api/Carteira/id
Delete{id}: https://localhost:7217/api/Carteira/id

  {
    "id": 0,
    "nome": "string",
    "cpfcnpj": "string",
    "email": "string",
    "senha": "string",
    "saldo": 0,
    "userType": 1 //1 para Lojista ou 2 para Usuario
  }
  
~~~~

#### Transações

~~~~
Post: https://localhost:porta/api/Transacao
Get: https://localhost:porta/api/Transacao
Get{id}: https://localhost:porta/api/Transacao/id
Delete{id}: https://localhost:porta/api/Transacao/id

  {
    "id": 0,
    "senderId": 0,
    "reciverId": 0,
    "valor": 0,
    "dataTrancacao": "2025-03-05T15:14:27.844Z"
  }

~~~~

## Frameworks utilizados

* EntityFrameworkCore
* EntityFrameworkCore.Tools
* EntityFrameworkCore.Design
* EntityFrameworkCore.SqlServer

## Banco de dados utilizado

* **SqlServer**