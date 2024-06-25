### 16. Конкурентное программирование. Асинхронные операции
- понятие конкуретного программирования
- отличие асинхронного программирования от многопоточного
- понятие процесса и потока
- запуск процессов и потоков из кода
- управление потоками напрямую
- пул потоков
- класс Task. Создание задачи и управление её жизненным циклом
- класс TaskFactory
- async/await. Конечный автомат. Оповещение о завершении асинхронной операции
- объединение и отмена выполнения задач
- обработка исключений в Task

#### Практика
1. Реализовать метод Save в FileStorage для сохранения одного экземпляра ProductItem из проекта Practice. Экземпляр
должен добавляться к существующему списку товаров, а не "перезатирать" его. Важно, чтобы после добавления товара
методы Fetch сохраняли работоспособность
2. Произвести рефакторинг метода Save для списка товаров так, чтобы в сигнатуре метода можно было указать необходимость
"перезатирания" исходного списка товаров. Важно, чтобы после рефакторинга методы Fetch сохраняли работоспособность

#### Домашнее задание
1. Изучить документацию по использованию класса Task:
   - [раз](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/task-based-asynchronous-programming)
   - [два](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/chaining-tasks-by-using-continuation-tasks)
   - [три](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/task-cancellation)
   - [четыре](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/exception-handling-task-parallel-library)
   - [пять](https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-return-a-value-from-a-task)
2. Прочитать статьи [раз](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/task-asynchronous-programming-model) и [два](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/async-scenarios) на MSDN и [статью](https://habr.com/ru/articles/470830/) на Хабр про концепцию async/await
3. Изучить [тему](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.whenall?view=net-8.0) асинхронного ожидания выполнения группы задач
4. Изучить [статью](https://devblogs.microsoft.com/dotnet/configureawait-faq/) о применении метода ConfigureAwait для приложений с переопределённым SynchronizationContext
5. Почитать [статью](https://devblogs.microsoft.com/pfxteam/task-run-vs-task-factory-startnew/) Стивена Тауба про сравнение Task.Run и Task.Factory.StartNew
6. Изучить [документацию](https://learn.microsoft.com/en-us/dotnet/standard/io/) по работе с I/O API
7. Ознакомиться с книгой Стивена Клири ["Concurrency in C#"](https://www.ozon.ru/product/konkurentnost-v-c-asinhronnoe-parallelnoe-i-mnogopotochnoe-programmirovanie-stiven-kliri-1103186035)
8. Реализовать методы FetchByName и FetchByCategory в FileStorage из проекта Practice
9. Реализовать generic-интерфейс IDataStorage и наследника FileDataStorage, с помощью которых возможна сериализация и
десериализация разных объектов (не только ProductItem), согласно следующим требованиям:
   - у каждой сущности, которую можно сохранить, должно быть свойство ID (Guid)
   - есть метод получения полного списка объектов
   - есть метод получения объекта по ID
   - есть метод сохранения единичного объекта
   - есть метод сохранения списка объектов (IEnumerable<T>)