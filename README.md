## :diamond_shape_with_a_dot_inside: Azure Function - Validador de CPF

 ## 📝Descrição
Este repositório contém um exemplo de implementação de uma Azure Function desenvolvida para validar números de CPF. A aplicação segue o paradigma de computação serverless, oferecendo alta escalabilidade, baixo custo e simplicidade no desenvolvimento.

## ❔ O que são Azure Functions?
As Azure Functions são uma solução de computação serverless da Microsoft que permite a execução de trechos de código (chamados de "funções") em resposta a eventos, como requisições HTTP, mensagens em filas, alterações em bancos de dados, entre outros.

Com Azure Functions, você não precisa gerenciar servidores ou infraestrutura — o Azure se encarrega de escalar automaticamente os recursos com base na demanda. Isso permite que os desenvolvedores se concentrem no código e nos objetivos do projeto, sem se preocupar com configurações complexas de servidores ou manutenção.

## 🛠️ Validador de CPF
Esta aplicação contém uma função chamada ValidateCPF, que recebe um número de CPF como parâmetro via uma requisição HTTP e verifica se ele é válido, retornando a resposta correspondente.

A função está exposta no endpoint:
```
https://validadorcpf-az20420250110114458.azurewebsites.net/api/validate-cpf/{cpf} 
```
<b>OBS: Permanece nesse endpoint por tempo limitado, pois a conta Azure que mantém a instância é uma conta Trial</b>

## ⏳ Fluxo da Função:
Entrada: A função recebe o CPF como parte do caminho da URL.
Validação: Um algoritmo verifica a validade do CPF com base nos dígitos verificadores.
Resposta: Retorna um JSON indicando se o CPF é válido ou não, com os seguintes formatos:
```
{
    "message": "O CPF 11122233356 é inválido.",
    "cpf": "11122233356",
    "isValid": false
}
```
```
{
    "message": "O CPF 111.222.333-56 é inválido.",
    "cpf": "111.222.333-56",
    "isValid": false
}
```

## ⭐ Vantagens do Serverless com Azure Functions
1. Escalabilidade Automática
O Azure ajusta automaticamente os recursos para lidar com altas demandas, garantindo que sua aplicação permaneça disponível mesmo em picos de tráfego.
2. Custo-Efetividade
Você paga apenas pelo tempo de execução da função. Quando ela não é utilizada, não há custo, o que é ideal para workloads esporádicos ou event-driven.
3. Fácil Integração
Azure Functions se integram perfeitamente com outros serviços do Azure, como Cosmos DB, Storage Queues, Event Hubs, e APIs HTTP.
4. Rápida Iteração
Com foco no desenvolvimento de código, você pode prototipar e entregar soluções rapidamente.

## 🚀 Como Executar Localmente:
1. Pré-requisitos
   - .NET 8 SDK instalado.
   - Azure CLI configurado para sua conta.
   - Visual Studio 22.
   - Dependências Instaladas via NuGet:
     ```
     using System.Net;
     using System.Text.Json;
     using Microsoft.Azure.Functions.Worker;
     using Microsoft.Azure.Functions.Worker.Http;
     using Microsoft.Extensions.Logging;
     ```

2. Buildar a Azure Function
   - Executar o comando:
     ```
     dotnet build
     ```

3. Executar a Azure Function
   - Executar o comando:
     ```
     func start
     ```

4. Utilizar a Azure Function
   - A função será executada localmente no seguinte endereço:
     ```
     http://localhost:7179/api/validate-cpf/{cpf}
     ```

## :handshake: Colaboradores
<table>
  <tr>
    <td align="center">
      <a href="https://github.com/AbnerBenicio">
        <img src="https://media.licdn.com/dms/image/D4D03AQEiFXDPPtHBgw/profile-displayphoto-shrink_800_800/0/1662566793828?e=1720051200&v=beta&t=TMcxwTB3utOnzfG5VsQPu0wkIah_CpHNdDjPo0_Ss9Y" width="100px;" alt="Foto de Abner Benicio"/><br>
        <sub>
          <b>Abner Benicio</b><br>
          <b>abnerbeniciosilva123@gmail.com</b>
        </sub>
      </a>
    </td>
  </tr>
</table>
