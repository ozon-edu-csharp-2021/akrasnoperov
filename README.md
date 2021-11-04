# OzonEdu.MerchandiseService
Проект предназначен для учета выдачи мерча сотрудникам.

Состоит из:
- OzonEdu.MerchandiseService — проект с основным asp.net core сервисом.
- OzonEdu.MerchandiseService.Infrastructure — Проект с инфраструктурой для основного сервиса.
- OzonEdu.MerchandiseService.Grpc — проект с grpc-сервисом.
- OzonEdu.MerchandiseService.HttpClients — проект с http-клиентом для интеграция с REST API сервиса.
- OzonEdu.MerchandiseService.HttpModels — проект с контрактами для REST API.
- OzonEdu.MerchandiseService.Domain — проект с доменными моделями.
- OzonEdu.MerchandiseService.Domain.Tests — проект с тестами для проекта OzonEdu.MerchandiseService.Domain.

Зависит от:
- supply-service - сервис поставок;
- emailing-service - сервис отправки электронной почты;
- employees-service - сервис сотрудников;
- stock-api - сервис отвечающий за остатки мерча на складе.