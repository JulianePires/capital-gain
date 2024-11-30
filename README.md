# CapitalGain

O projeto foi criado para atender o desafio da vaga de Software Engeneering do Nubank, trazendo uma Console Aplication
em C# rodando em um container Docker.

## Referência

O projeto foi construído a partir do documento a seguir:

![Desafio Nubank PDF](https://github.com/JulianePires/capital-gain/blob/main/Assets/Code_Challenge__Ganho_de_Capital_ptbr.pdf)

## Estruturação do Projeto

O projeto foi criado em formato de Console Application em C#, seguindo práticas de código, TDD e Arquitetura Limpa.

![Arquitetura Limpa](https://miro.medium.com/v2/resize:fit:1400/1*kr_9fUVjtMI56OlSj2fGMQ.png)

O conceito de Arquitetura Limpa foi escolhido por segregar o código em camadas de Domínio (modelagem e tratamento dos
dados e casos de uso), Dados (implementação dos dados e casos de uso da aplicação) e Apresentação (interação direta com
o usuário, onde os dados da aplicação são captados/apresentados), trazendo uma maior compreensão de estutura, segregação
das camadas e, consequentemente, facilidade para testar. Além disso, teremos também Mappers, que tratarão esses dados
vindos da camada de apresentação para corresponder ao que foi criado lá no Domínio.

![Camadas da aplicação](https://miro.medium.com/v2/resize:fit:640/format:webp/1*E_cnDk6Pdiz5-OjD3nuGPQ.png)

Os diretório ficam dispostos da seguinte maneira:

```shell
$tree
  .
  ├───Business - Desenvolvimento do negócio
  ├───Data - Camada de dados (Aplication Layer)
  │   └───Services - Serviços de dados (recebe os dados e encaminha para a cada de negócio)
  ├───Domain - Camada de domínio (Modelagem e tratamento dos dados)
  │   ├───Contracts - Contratos de negócio
  │   ├───Entities - Entidades
  │   └───UseCases - Casos de uso
  ├───Helpers - Classes de apoio
    
```

## Rodando os testes

Para rodar os testes, rode o seguinte comando

```bash
  dotnet test
```

## Rodando a aplicação local

Para rodar a aplicação local, rode o seguinte comando

```bash
  dotnet run
```

## Rodando a aplicação em um container Docker

Para rodar a aplicação em um container Docker, rode o seguinte comando

```bash
  docker build -t capitalgain -f CapitalGain\Dockerfile .
  docker run -it capitalgain
```

Você pode utilizar os exemplos para testar a aplicação, ou inserir os seus próprios dados:

```bash
    [{"operation":"buy", "unit-cost":10.00, "quantity": 100}, {"operation":"sell", "unit-cost":15.00, "quantity": 50}, {"operation":"sell", "unit-cost":15.00, "quantity": 50}]
    [{"operation":"buy", "unit-cost":10.00, "quantity": 10000}, {"operation":"sell", "unit-cost":20.00, "quantity": 5000}, {"operation":"sell", "unit-cost":5.00, "quantity": 5000}]
```

A saída esperada é:

```bash
   [{"tax":"0.00"},{"tax":"0.00"},{"tax":"0.00"}][{"tax":"0.00"},{"tax":"10000.00"},{"tax":"0.00"}]
```

## Observações

Tive que alterar o retorno da saída do JSON por conta da formatação da resposta.

## Autor

- [@JulianePires](https://www.github.com/JulianePires)

```