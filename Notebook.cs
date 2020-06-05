using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV6
{
    class Note
    {
        public string Title { get; private set; }    
        public string Text { get; private set; }

        public Note(string title, string text) 
        {
            this.Title = title;
            this.Text = text;
        }

        private int GetFrameWidth()
        {
            return this.Title.Length < this.Text.Length ? this.Text.Length : this.Title.Length; 
        }        
        private string GetRule(char c) 
        { 
            return new string(c, this.GetFrameWidth());
        }

        public void Show() 
        {
            Console.WriteLine(this.GetRule('='));
            Console.WriteLine(this.Title);
            Console.WriteLine(this.GetRule('-'));
            Console.WriteLine(this.Text);
            Console.WriteLine(this.GetRule('='));
        }
    }

    interface IAbstractCollection 
    { 
        IAbstractIterator GetIterator();   
    }

    interface IAbstractIterator 
    {
        Note First();
        Note Next();
        bool IsDone { get; }
        Note Current { get; } 
    }
 
     class Notebook : IAbstractCollection    
     {    
         private List<Note> notes; 
 
        public Notebook() 
        { //implementation missing!
            this.notes = new List<Note>();
        }
        public Notebook(List<Note> notes)
        {          
            this.notes = new List<Note>(notes.ToArray());     
        } 
 
        public void AddNote(Note note)
        { //implementation missing! 
            this.notes.Add(note);
        }       
         public void RemoveNote(Note note)
         { //implementation missing!
             this.notes.Remove(note);
         }        
         public void Clear() 
         {//implementation missing!
             this.notes.Clear();
         }         
         public int Count { get { return this.notes.Count; } }    
         public Note this[int index] { get { return this.notes[index]; } }    
         public IAbstractIterator GetIterator()
         {
             return new Iterator(this);
         } 
     }
     class Iterator : IAbstractIterator
     {
         private Notebook notebook; 
         private int currentPosition;

         public Iterator(Notebook notebook)
         {
             this.notebook = notebook; this.currentPosition = 0; 
         }

         public bool IsDone
         {
             get
             {
                 return this.currentPosition >= this.notebook.Count; 
             } 
         } 
         public Note Current { get { return this.notebook[this.currentPosition]; } }     
         public Note First() { return this.notebook[0]; }       
         public Note Next()
         { 
             this.currentPosition++; 
             if (this.IsDone)
             { return null; } 
             else 
             { return this.notebook[this.currentPosition]; }
         }
     }

     class Program
     {
         Notebook notes;
         Iterator iter = new Iterator();
 
     }
}
