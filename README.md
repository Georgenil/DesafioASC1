# Sistema de Gestão de Reservas de Salas

Este sistema foi desenvolvido para ser entregue dentro do prazo de 4 dias, visando centralizar e otimizar o processo de agendamento de salas, eliminando o uso de planilhas, e-mails e outros métodos descentralizados. Com uma interface moderna e intuitiva, ele é ideal para pequenas e médias empresas que buscam uma gestão eficiente, segura e escalável de seus espaços físicos. 

Por meio dele, é possível: 

- Cadastrar, editar, visualizar e excluir salas com informações personalizadas, como nome e capacidade máxima; 
- Gerenciar reservas de maneira prática, garantindo que a ocupação respeite a capacidade da sala e evitando conflitos de horários; 
- Validar automaticamente a disponibilidade dos espaços no momento da reserva, promovendo agilidade e confiabilidade no processo. 

## Pré-requisitos
- .NET 8 SDK

## Tecnologias usadas
- .NET 8
- SQL SERVER
- ENTITY FRAMEWORK CORE

## Decisões arquiteturais
- CLEAN ARCHITECTURE
- DDD
- CQRS
- MEDIATOR (Com Dispatcher, MediatR se tornou pago)
- REPOSITORY PATTERN
- SOLID
- POLLY

## Ajustes e melhorias
- Melhorar a resiliência para que ela seja mais específica (decidir onde vale a pena usar Circuit Breaker, etc) em cenários onde o consumo de API's Externa pode acontecer e  fazer uma análise
- Criar interfaces mais granulares ao invés de usar ISalaRepository
  
## Configuração
1. Em `appsettings.json` configure a string de conexão.

<img width="339" height="76" alt="image" src="https://github.com/user-attachments/assets/c7b3f50e-b2d0-4930-88bf-700bc0e7ae75" />

2. Aplique as migrações: `dotnet ef database update`.

## Link para a documentação PDF
https://drive.google.com/file/d/1xOvGN6LwvRIhohWZomSJmp0Xm5b69EV0/view?usp=sharing
