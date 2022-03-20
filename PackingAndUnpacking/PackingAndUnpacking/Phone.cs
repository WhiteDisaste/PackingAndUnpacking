using System;

namespace PackingAndUnpacking
{
    public class Phone<T> 
    {
        public T Id { get; set; }
        public int Price { get; set; }
         
        public string Model { get; set; }

       // public abstract T GetNextId();
    }
    
    public class DanyaPhone : Phone<int>
    {   
        //с 0, максимальное 32768 (int16), в данном случае - 2млн блаблабла
        // 0, 0+1 = 1, 1+1 = 2
        public int Id { get; set; }

        // public override int GetNextId()
        // {
        //     return this.Id + 1;
        // }
    }
    
    public class AnyaPhone : Phone<Guid>
    {
        //хочу продавать миллионы телефонов на 100 лет подряд (по миллиону телефонов в год)
        public Guid Id { get; set; }

        // public override Guid GetNextId()
        // {
        //     return Guid.NewGuid();
        // }
    }
}