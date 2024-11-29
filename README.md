﻿
# CapitalGain

O projeto foi criado para atender o desafio da vaga de Software Engeneering do Nubank, trazendo uma Console Aplication em C# rodando em um container Docker.


## Referência

O projeto foi construído a partir do documento a seguir:

![Desafio Nubank PDF](./Assets/Code_Challenge__Ganho_de_Capital_ptbr.pdf)

## Estruturação do Projeto

O projeto foi criado em formato de Console Application em C#, seguindo práticas de código, TDD e Arquitetura Limpa.

![Arquitetura Limpa](https://miro.medium.com/v2/resize:fit:1400/1*kr_9fUVjtMI56OlSj2fGMQ.png)

O conceito de Arquitetura Limpa foi escolhido por segregar o código em camadas de Domínio (modelagem e tratamento dos dados e casos de uso), Dados (implementação dos dados e casos de uso da aplicação) e Apresentação (interação direta com o usuário, onde os dados da aplicação são captados/apresentados), trazendo uma maior compreensão de estutura, segregação das camadas e, consequentemente, facilidade para testar. Além disso, teremos também Mappers, que tratarão esses dados vindos da camada de apresentação para corresponder ao que foi criado lá no Domínio.

![Camadas da aplicação](https://miro.medium.com/v2/resize:fit:640/format:webp/1*E_cnDk6Pdiz5-OjD3nuGPQ.png)

Os diretório ficam dispostos da seguinte maneira:

```shell
$tree
  .
  ├───Business
  ├───Data
  │   └───Services
  ├───Domain
  │   ├───Contracts
  │   ├───Entities
  │   └───UseCases
  ├───Helpers
    
```
