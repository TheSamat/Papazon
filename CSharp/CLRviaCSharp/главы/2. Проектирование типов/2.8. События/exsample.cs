//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace LeetCodeIsGovno.CLRviaCSharp.главы._2._Проектирование_типов._2._8._События
//{

//    public class Program
//    {
//        private static void Main(string[] args)
//        {
//            #region вариант метанита
//            Account acc = new Account(100);
//            acc.Notify += DisplayMessage;       // добавляем обработчик DisplayMessage
//            acc.Put(20);    // добавляем на счет 20
//            acc.Notify -= DisplayMessage;     // удаляем обработчик DisplayMessage
//            acc.Put(20);    // добавляем на счет 20

//            void DisplayMessage(string message) => Console.WriteLine(message);
//            #endregion

//            #region 1 вариант
//            MailManager mailManager = new MailManager();
//            Fax fax = new Fax(mailManager);

//            mailManager.SimulateNewMail("from", "to", "subject");

//            fax.Unregister(mailManager);
//            mailManager.SimulateNewMail("from", "to", "subject");
//            #endregion

//            #region 2 вариант
//            TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();
//            Post post = new Post();

//            // Добавление обратного вызова
//            twle.Foo += post.Posting;

//            // Проверяем работоспособность
//            twle.SimulateFoo();
//            #endregion
//        }
//    }
//    #region вариант метанита
//    class Account
//    {
//        public delegate void AccountHandler(string message);
//        AccountHandler notify;
//        public event AccountHandler Notify
//        {
//            add
//            {
//                notify += value;
//                Console.WriteLine($"{value.Method.Name} добавлен");
//            }
//            remove
//            {
//                notify -= value;
//                Console.WriteLine($"{value.Method.Name} удален");
//            }
//        }
//        public Account(int sum) => Sum = sum;
//        public int Sum { get; private set; }
//        public void Put(int sum)
//        {
//            Sum += sum;
//            notify?.Invoke($"На счет поступило: {sum}");   // 2.Вызов события 
//        }
//        public void Take(int sum)
//        {
//            if (Sum >= sum)
//            {
//                Sum -= sum;
//                notify?.Invoke($"Со счета снято: {sum}");   // 2.Вызов события
//            }
//            else
//            {
//                notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}"); ;
//            }
//        }
//    }
//    #endregion

//    #region 1 вариант

//    #region уведомление
//    //просто содержит доп инфу для события
//    internal class NewMailEventArgs : EventArgs
//    {
//        private readonly String m_from, m_to, m_subject;
//        public NewMailEventArgs(String from, String to, String subject)
//        {
//            m_from = from; m_to = to; m_subject = subject;
//        }
//        public String From { get { return m_from; } }
//        public String To { get { return m_to; } }
//        public String Subject { get { return m_subject; } }
//    }
//    #endregion
//    #region уведомитель
//    //обработчик событий
//    internal class MailManager
//    {
//        //событие
//        public event EventHandler<NewMailEventArgs> NewMail;

//        // Если этот класс изолированный, нужно сделать метод
//        // закрытым или невиртуальным

//        //рассылка подписчикам уведомление / вызов методов события
//        protected virtual void OnNewMail(NewMailEventArgs e)
//        {
//            EventHandler<NewMailEventArgs> temp = NewMail;
//            if (temp != null) temp(this, e);
//        }

//        //запуск (хз как это использовать надо)
//        public void SimulateNewMail(String from, String to, String subject)
//        {
//            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);
//            OnNewMail(e);
//        }
//    }
//    #endregion
//    #region подписчик
//    //пример типа, использующий событие
//    internal sealed class Fax
//    {
//        public Fax(MailManager mm)
//        {
//            mm.NewMail += FaxMsg;
//        }
//        //метод, обратного вызова
//        private void FaxMsg(Object sender, NewMailEventArgs e)
//        {
//            Console.WriteLine("Faxing mail message:");
//            Console.WriteLine(" From={0}, To={1}, Subject={2}", e.From, e.To, e.Subject);
//        }
//        //отписаться от события
//        public void Unregister(MailManager mm)
//        {
//            mm.NewMail -= FaxMsg;
//        }
//    }
//    #endregion

//    #endregion

//    #region 2 вариант

//    #region тип, поддерживающий логику самой коллекции (событий)
//    public sealed class EventKey : Object { }
//    public sealed class EventSet
//    {
//        //коллекция (событие, делегаты события)
//        private readonly Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();

//        //добавление делегата в событие по id
//        public void Add(EventKey eventKey, Delegate handler)
//        {
//            Monitor.Enter(m_events);
//            Delegate d;
//            m_events.TryGetValue(eventKey, out d);
//            m_events[eventKey] = Delegate.Combine(d, handler);
//            Monitor.Exit(m_events);
//        }

//        //удаление делегата из события по id
//        public void Remove(EventKey eventKey, Delegate handler)
//        {
//            Monitor.Enter(m_events);
//            Delegate d;
//            if (m_events.TryGetValue(eventKey, out d))
//            {
//                d = Delegate.Remove(d, handler);
//                if (d != null) m_events[eventKey] = d;
//                else m_events.Remove(eventKey);
//            }
//            Monitor.Exit(m_events);
//        }

//        //рассылка подписчикам / вызов методов
//        public void Raise(EventKey eventKey, Object sender, EventArgs e)
//        {
//            Delegate d;
//            Monitor.Enter(m_events);
//            m_events.TryGetValue(eventKey, out d);
//            Monitor.Exit(m_events);
//            if (d != null)
//            {
//                d.DynamicInvoke(new Object[] { sender, e });
//            }
//        }
//    }
//    #endregion
//    #region обработчик событий
//    public class FooEventArgs : EventArgs { }   //удедомление
//    public class TypeWithLotsOfEvents
//    {
//        //коллекция событий
//        private readonly EventSet m_eventSet = new EventSet();
//        protected EventSet EventSet { get { return m_eventSet; } }

//        #region Паттерн сопровождения коллекций событий
//        protected static readonly EventKey s_fooEventKey = new EventKey();

//        //событие Foo и его "свойства"
//        public event EventHandler<FooEventArgs> Foo
//        {
//            add { m_eventSet.Add(s_fooEventKey, value); }
//            remove { m_eventSet.Remove(s_fooEventKey, value); }
//        }

//        //рассылка подписчикам уведомление / вызов методов события
//        protected virtual void OnFoo(FooEventArgs e)
//        {
//            m_eventSet.Raise(s_fooEventKey, this, e);
//        }

//        //запуск (по прежнему хз как он работает)
//        public void SimulateFoo() { OnFoo(new FooEventArgs()); }
//        #endregion
//    }
//    #endregion
//    #region подписчик
//    internal sealed class Post
//    {
//        public Post() { }
//        public Post(TypeWithLotsOfEvents mm)
//        {
//            mm.Foo += Posting;
//        }

//        //метод, обратного вызова
//        public void Posting(Object sender, FooEventArgs e)
//        {
//            Console.WriteLine("Posting FooEventArgs: ...");
//        }

//        //отписаться от события
//        public void Unregister(TypeWithLotsOfEvents mm)
//        {
//            mm.Foo -= Posting;
//        }
//    }
//    #endregion

//    #endregion
//}

