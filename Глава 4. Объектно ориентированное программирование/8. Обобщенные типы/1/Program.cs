Collection<int> numbers = new Collection<int>();

numbers.Add(1);
numbers.Add(3);
numbers.Add(5);

numbers.Remove(2);
numbers.Remove(3);

for(int i = 0; i < numbers.Count(); i++) 
{
    Console.WriteLine(numbers.Getitem(i));
}
// если бы не уровень защиты поля data то можно было бы заменить numbers.Count() и numbers.Getitem(i), соответственно на numbers.data.Length и numbers.data[i].

class Collection<T>
{
    T[] data; // создается ячейка памяти для хранения массива и ссылка на эту ячейку data, но сам массив еще не создан.
    public Collection()
    {
        data = new T[0]; // Создается массив. При создании массива без перечисления его элементов обязательно нужно указать его длинну.
    }
    // добавление данных.
    public void Add(T item)
    {
        T[] newdata = new T[data.Length + 1];
        for(int i = 0; i < data.Length; i++) // если data пустой то цикл ни разу не сработает.
        {
            newdata[i] = data[i];
        }
        newdata[data.Length] = item; // если data пустой то newdata[0] = item.
        data = newdata;
    }
    // удаление первого вхождения элемента при его наличии.
    public void Remove(T item)
    {
        // находим индекс удаляемого элемента
        int index = -1; // index объявляется заранее, а не в цикле, потомучто могут передать item, которого нет в массиве и условие if не сработает. При простом объявлении без присвоения index получает значение по умолчанию 0, поэтому задаем значение -1, т.к. значения для i будут перебиратся от нуля до data.Length - 1 в цикле, следовательно задаем самое маленькое значение, которое не может принять i, чтобы было ясно был ли найден индекс удаляемого элемента массива.
        for(int i = 0; i < data.Length; i++)
        {
            if(data[i].Equals(item))
            {
                index = i;
                break;
            }
        }
        // удаляем элемент по индексу.
        if(index > -1)
        {
            T[] newdata = new T[data.Length - 1];
            for(int i = 0, j = 0; i < data.Length; i++)
            {
                if(i == index) continue; // continue пропускает (отменяет) оставшуюся часть итерации, и переходит к новой итерации. i++ срабатывает после каждой итерации цикла.
                newdata[j] = data[i];
                j++;
            }
            data = newdata;
        }
    }
    // получение элемента по индексу.
    public T Getitem(int index)
    {
        if(index > -1 && index < data.Length)
        {
            return data[index];
        }
        else
        {
            throw new IndexOutOfRangeException(); // генерирует исключение.
        }
    }
    // получение длинны массива.
    public int Count()
    {
        return data.Length;
    }
}

