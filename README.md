# MathPlot
## Проект для отображения некоторых математических графиков

### Стэк технологий
- Vue.js
- Entity Framework Core
- ASP.NET Core
- PostgreSQL

### О чем проект?
Проект расчитан на то, что пользователь сможет расширить свои знания в нелинейной физике а так же сможет построить графики некоторых одномерных отображений

### Какой есть функционал?
- Регистрация/Авторизация
- Возможность редактировать личную информацию
- Возможность сохранения построенных графиков в БД
- Возможность просматривать сохраненные графики
- Скачивание графика в формате png
- Простая система комментариев на страница с теорией

### Как запустить проект?
В файле appsettings.json необходимо заменить значение в ключе MainPath на ваш **полный** путь к папке src\UserCharts. Аналогично заменить значение по ключу MainUserPath на полный путь к папке src\UserImages
```sh
"SaveImgPath": {
    "MainPath": "C:\\Users\\Admin\\source\\repos\\MathPlot\\MathPlot\\mathplot.ui\\src\\UserCharts",
    "MainUserPath": "C:\\Users\\Admin\\source\\repos\\MathPlot\\MathPlot\\mathplot.ui\\src\\UserImages"
  },
```
Возможно нужно будет поставить дамб БД, его можно найти в файлах проекта