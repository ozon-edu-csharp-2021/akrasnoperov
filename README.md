# OzonEdu.MerchandiseService
Проект предназначен для учета выдачи мерча сотрудникам.

Состоит из:
- OzonEdu.MerchandiseService — проект с основным asp.net core сервисом.
- OzonEdu.MerchandiseService.Grpc - проект с grpc-сервисом.
- OzonEdu.MerchandiseService.HttpClients - проект с http-клиентом для интеграция с REST API сервиса.
- OzonEdu.MerchandiseService.HttpModels - проект с контрактами для REST API.

Зависит от:
- supply-service - сервис поставок;
- emailing-service - сервис отправки электронной почты;
- employees-service - сервис сотрудников;
- stock-api - сервис отвечающий за остатки мерча на складе.

Если при вызове Grpc получаете ошибку `14 UNAVAILABLE: Trying to connect an http1.x server`,
то в `Program` нужно добавить `webBuilder.ConfigureKestrel(kestrel => kestrel.ConfigureEndpointDefaults(kk => kk.Protocols = HttpProtocols.Http2));`.