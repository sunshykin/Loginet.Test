# [EN] Loginet.Test

Test Task for Loginet company.

## Description
Create an application, desribed below using C#.

**Create web service, which provides the following features:**
- Providing a list of all users
- Providing a user data by Id
- Providing a list of all albums
- Providing all user albums
- Providing an album by Id

**Additional features:**
- The data should be received from [Public API](http://jsonplaceholder.typicode.com/).
- Providing data as XML and JSON
- User's email should be treated as sensitive data (third person can not get an access to that). But that sensitive data should be seen for the user

## Quick Start
Because of task restrictions, the project does not have a real DB, so Authorization-Authentication process is also cut down.

The Auth process uses Cookie and goes by /api/auth method, which you can send a POST request containing email of user you want to log in, either GET request with query parameter 'email'. The second one is used to accessing API Auth from the browser only.

After you logged in, you can see the sensitive data of your user only (there are no roles so just be content with what you have).

---

## [RU] Описание
Напишите приложение, описанное далее. Код должен быть написан на языке С# (Visual Studio Community или VS Code).

**Создайте веб сервис, который предоставляет следующие возможности:**
- Получение списка всех пользователей
- Получение пользователя по id
- Получение списка всех альбомов
- Получение всех альбомов одного пользователя
- Получение альбома по id

**Дополнительные требования:**
- Сервис должен получать данные из [Публичного API](http://jsonplaceholder.typicode.com/).
- Сервис должен предоставлять данные в формате JSON и XML
- Email пользователя – это личные данные (третья сторона не должна суметь прочитать их), но должен быть включен в ответ на запрос веб сервиса

## Быстрый старт
Из-за ограничений в проекте нет реальной БД, поэтому процесс авторизации-аутентификации сильно урезан.

В процессе используются Cookie, а для авторизации служит метод /api/auth. Можно авторизоваться через POST запрос, содержащий адрес электронной почты пользователя, под которым Вы хотите войти в систему, либо же отправить GET запрос с query-параметром 'email'. Второй используется лишь для доступа к API авторизации из браузера без установки дополнительных средств.

После входа в систему Вы сможете видеть конфиденциальные данные только для своего пользователя (ролей нет, поэтому довольствуемся тем, что есть).
