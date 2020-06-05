using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV6
{
    class Memento
    {
    }

    enum MessageType    
    {     
        INFO = 1,       //  1    
        WARNING = 2,    // 10   
        ERROR = 4,      //100  
        ALL = 7         //111    
    } 

    abstract class AbstractLogger  
    {       
        protected MessageType messageTypeHandling;   
        protected AbstractLogger nextLogger; 
 
        public AbstractLogger(MessageType messageType) 
        {     
            this.messageTypeHandling = messageType;    
        } 
 
        public void SetNextLogger(AbstractLogger logger)
        {         
            this.nextLogger = logger;   
        } 
 
        public void Log(string message, MessageType type)
        {     
            if ((type & this.messageTypeHandling) != 0)
            {           
                this.WriteMessage(message, type);    
            }         
            if (this.nextLogger != null)
            {        
                this.nextLogger.Log(message, type);  
            }       
        }   
        protected abstract void WriteMessage(string message, MessageType type);
    } 

     class ConsoleLogger : AbstractLogger   
     {      
         public ConsoleLogger(MessageType messageType) : base(messageType) { } 
 
        protected override void WriteMessage(string message, MessageType type)
        {           
            Console.WriteLine(type + ": " + DateTime.Now);      
            Console.WriteLine(new string('=', message.Length));   
            Console.WriteLine(message);         
            Console.WriteLine(new string('=', message.Length) + "\n");     
        }   
     } 
     class FileLogger : AbstractLogger  
     {      
         private string filePath; 
 
        public FileLogger(MessageType messageType, string filePath) : base(messageType)
        {         
            this.filePath = filePath; 
        } 
 
        protected override void WriteMessage(string message, MessageType type)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter("@filePath"))
            {
                file.WriteLine(type + ": " + DateTime.Now);
                file.WriteLine(new string('=', message.Length));
                file.WriteLine(message);
                file.WriteLine(new string('=', message.Length) + "\n");
            }
        }  
     }
     class Program
     {
         static void Main(string[] args)
         {
             AbstractLogger logger = new ConsoleLogger(MessageType.ALL);
             FileLogger fileLogger = new FileLogger(MessageType.ALL, "logFile.txt");
             logger.GetType();
             logger.Log("Message 1 1", MessageType.ALL);
             fileLogger.GetType();
             fileLogger.Log("Message 2 2",MessageType.ALL);
         }
     }
}
