# Kaz.Operations

Набор утилит для работы со строками, числовыми преобразованиями и коллекциями.  
Пакет расширяет стандартные возможности .NET и предоставляет единый API для базовых операций.

Зависимость: `Kaz.Operations.Core`

---

## Возможности

---
- ### `Kaz.Operations.Text`

    - #### Валидация строк и удаление пробелов:

       ```csharp
        string value = input.ValidateString();
        ```
        **или**

        ```csharp
        string value = input.TryValidateString();
        ```
    
    - #### При ошибке используется исключение

        ```csharp
        Kaz.Operations.Core.StringValidationException();
        ```

---
- ### `Kaz.Operations.Numerics`

    - #### Безопасное преобразование строки в число с использованием InvariantCulture:

        ```csharp
        int number = input.ToNumericOrDefault<int>(0);
        ```
    
---
- ### `Kaz.Operations.Collections`

    - #### Алгоритмы сортировки для IList<T>:

        ```csharp
        int[] list = {3, 2, 1};

        list.MergeSort();
        ```

        **также доступны:**

        ```csharp
        int[] list = {3, 2, 1};

        list.BubbleSort();
        ```

        - **или**


        ```csharp
        int[] list = {3, 2, 1};

        list.SelectionSort();
        ```

    ---
    - **Заметка:** `BubbleSort` и `SelectionSort` помечены как устаревшие и не рекомендуются к использованию (только в учебных целях).
        
---
## Установка 

```bash
dotnet add package Kaz.Operations
```

---
## Ссылки

- [NuGet](https://www.nuget.org/packages/Kaz.Operations)
