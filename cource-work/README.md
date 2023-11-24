# Курсова работа

1.	Условие\
Да се изработят уеб услуги за управление на онлайн библиотека.

 2.	Задължителни изисквания за проекта\
Уеб услугите трябва да предоставя следната функционалност: добавяне, изтриване, четене и редактирането на книги. Трябва да се предостави възможност и за търсене по име на книга.
    1.	Структурата на базата от данни трябва да спазва следните правила
        1.	Минимум 2 свързани таблици (схемата е обвързана с тематиката на проекта ви)
        2.	Всяка таблица трябва да има минимум 6 колони, от които поне 4 да са с различни типове (int, double, long, DateTime и т.н.)
        3.	Всяка таблица трябва да съдържа поне 1 задължително поле (първичният ключ не се зачита)
        4.	Всяка текстова колона (ако има такава) трябва да има ограничение за максималния брой на символите в нея

Пример:
```
public class Book {
 public int Id { get; set; }
 public string Title { get; set; }
 public string Description { get; set; }
 public DateTime ReleaseDate { get; set; }
 public DateTime CreatedOn { get; set; }

 public Genre GenreId { get; set; }
 public virtual ICollection<Genre> Genres { get; set; }
}

public class Genre {
 public int Id { get; set; }
 public string Name { get; set; }
 public string Description { get; set; }
 public DateTime CreatedOn { get; set; }

 public virtual ICollection<Book> Books { get; set; }
}
```

4.	Позволен технологичен стак\
    *	C#, .Net Core Web API 2 или всяка друга рамка за разработка на уеб услуги
