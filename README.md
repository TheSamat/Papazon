# Papazon
Тестовый проект для практики

Приложение разбито на 4 слоя:
  	1.  Core
    	1.1.  Domain
    	1.2.  Application ->  Core.Domain
	2.  Infrastructure
  		2.1.  Persistence ->  Core.Application
  	3.  Presentation
  		3.1.  WebApi
  	4.  Test
  
Test -> Presentation  ->  Infrastructure  ->  Core

Core  - Ядро, внутренний слой, содержащий
	Domain - Подслой, содержащий  enterprise логику и типы. Может использоваться для других проектов
	Application - Подслой, содержащий  Бизнесс логику и типы. Используется для конкретно этого проекта
Infrastructure  - 2ой слой, содержащий логику обращения к бд
  	Persistence  - изолированная логика чтения/записи/удаления записей на базу данных.
Presentation  - 3ий слой, содержащий логику представления самого приложения. В нашем - wep api
  	WebApi - функционал приложения
Test  - вшешний слой, отвечающий за анализ целостности слоёв



