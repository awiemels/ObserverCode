using System;
using System.Collections.Generic;
 
namespace DoFactory.GangOfFour.Observer.Structural
{
  /// <summary>

  /// MainApp startup class for Structural 

  /// Observer Design Pattern.

  /// </summary>

  class MainApp

  {
    /// <summary>

    /// Entry point into console application.

    /// </summary>

    static void Main()
    {
      // Configure Observer pattern

      Celebrity s = new Celebrity();
      s.Name = "Michael Jackson";

      s.Follow(new Follower(s, "Carl"));
      s.Follow(new Follower(s, "Emily"));
 
      // Change subject and notify observers

      s.Tweet = "hey guys I am going to disney world";
      s.Notify();
        
      Console.WriteLine("");

      s.Tweet = "I just got off Space Mountain, it was wicked";
      s.Notify();
 
      // Wait for user

      Console.ReadKey();
    }
  }
 
  /// <summary>

  /// The 'Subject' abstract class

  /// </summary>

  abstract class Subject

  {
    private List<Observer> _observers = new List<Observer>();
 
    public void Follow(Observer observer)
    {
      _observers.Add(observer);
    }
 
    public void UnFollow(Observer observer)
    {
      _observers.Remove(observer);
    }
 
    public void Notify()
    {
      foreach (Observer o in _observers)
      {
        o.Update();
      }
    }
  }
 
  /// <summary>

  /// The 'ConcreteSubject' class

  /// </summary>

  class Celebrity : Subject

  {
    private string _tweet;
    private string _name;

    public string Name
    {
        get{return _name;}
        set {_name = value;}

    }
 
    // Gets or sets subject state

    public string Tweet
    {
      get { return _tweet; }
      set { _tweet = value; }
    }
  }
 
  /// <summary>

  /// The 'Observer' abstract class

  /// </summary>

  abstract class Observer

  {
    public abstract void Update();
  }
 
  /// <summary>

  /// The 'ConcreteObserver' class

  /// </summary>

  class Follower : Observer

  {
    private string _name;
    private string _observerState;
    private Celebrity _subject;
 
    // Constructor

    public Follower(
      Celebrity subject, string name)
    {
      this._subject = subject;
      this._name = name;
    }
 
    public override void Update()
    {
      _observerState = _subject.Tweet;
      Console.WriteLine("Hey {0} you have a message from {2}: {1} ",
        _name, _observerState, _subject.Name);
    }
 
    // Gets or sets subject

    public Celebrity Subject
    {
      get { return _subject; }
      set { _subject = value; }
    }
  }
}
 
 
    
      