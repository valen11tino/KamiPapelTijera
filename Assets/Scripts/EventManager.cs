using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//este es el mejor script del mundo, tengo un diccionario de eventos (que yo elijo los nombres jeje) y de metodos con parametros genericos (gg easy)
//entonces en cualquier script del juego puedo llamar a EventManager.Trigger, .Subscribe y .Unsubscribe

//trigger hace que todos los que se haya suscrito ejecuten sus metodos elegidos
//subscribe hace que adhiera a mis metodos para ser disparados cuando alguien mande trigger
//unsubscribe lo quita. hay que hacerlo siempre que vaya a destruir el objeto.

public enum Evento
{
    //eventos
    OnPlayerPressedE,
    OnPlayerPressedQ,
    OnPlayerPressedSpace,
    OnPlayerMove //cuando hor o ver son != 0. los params son 0 hor y 1 ver
}

public class EventManager
{
    public delegate void EventReceiver(params object[] parameters);

    static Dictionary<Evento, EventReceiver> _events = new Dictionary<Evento, EventReceiver>();

    public static void Subscribe(Evento evento, EventReceiver metodo)
    {
        if (!_events.ContainsKey(evento))
        {
            _events.Add(evento, metodo);
        }
        else
        {
            _events[evento] += metodo;
        }
    }

    public static void Unsubscribe(Evento evento, EventReceiver metodo)
    {
        if (_events.ContainsKey(evento))
        {
            _events[evento] -= metodo;
        }
    }

    public static void Trigger(Evento evento, params object[] parameters)
    {
        if (_events.ContainsKey(evento))
        {
            _events[evento](parameters);
        }
    }
}
