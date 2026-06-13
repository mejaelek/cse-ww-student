// LinkedList.cs
// CSE 212 - Week 04 Assignment

using System.Collections.Generic;
using System.Diagnostics;

public class LinkedList
{
    private Node? _head;
    private Node? _tail;

    // ================================================================
    //  Helper — used by tests to verify empty list state
    // ================================================================
    public bool HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // ================================================================
    //  Helper — used by tests to verify non-empty list state
    // ================================================================
    public bool HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }

    // ================================================================
    //  PROVIDED — InsertHead
    // ================================================================
    public void InsertHead(int value)
    {
        Node newNode = new Node(value);

        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head;
            _head.Prev   = newNode;
            _head        = newNode;
        }
    }

    // ================================================================
    //  Problem 1 — InsertTail                              O(1)
    // ================================================================
    public void InsertTail(int value)
    {
        Node newNode = new Node(value);

        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = _tail;
            _tail.Next   = newNode;
            _tail        = newNode;
        }
    }

    // ================================================================
    //  PROVIDED — RemoveHead
    // ================================================================
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head      = _head.Next;
            if (_head is not null)
                _head.Prev = null;
        }
    }

    // ================================================================
    //  Problem 2 — RemoveTail                              O(1)
    // ================================================================
    public void RemoveTail()
    {
        if (_tail is null) return;

        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else
        {
            _tail      = _tail.Prev;
            if (_tail is not null)
                _tail.Next = null;
        }
    }

    // ================================================================
    //  PROVIDED — InsertAfter
    //  Inserts a new node with newValue immediately after the first
    //  node found containing value.
    // ================================================================
    public void InsertAfter(int value, int newValue)
    {
        Node? current = _head;

        while (current is not null)
        {
            if (current.Data == value)
            {
                // Inserting after the tail uses InsertTail
                if (current == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new Node(newValue);
                    newNode.Prev         = current;
                    newNode.Next         = current.Next;
                    if (current.Next is not null)
                        current.Next.Prev = newNode;
                    current.Next         = newNode;
                }

                return;
            }

            current = current.Next;
        }
    }

    // ================================================================
    //  Problem 3 — Remove                                  O(n)
    // ================================================================
    public void Remove(int value)
    {
        Node? current = _head;

        while (current is not null)
        {
            if (current.Data == value)
            {
                if (current == _head)
                {
                    RemoveHead();
                }
                else if (current == _tail)
                {
                    RemoveTail();
                }
                else
                {
                    if (current.Prev is not null)
                        current.Prev.Next = current.Next;

                    if (current.Next is not null)
                        current.Next.Prev = current.Prev;
                }

                return;
            }

            current = current.Next;
        }
    }

    // ================================================================
    //  Problem 4 — Replace                                 O(n)
    // ================================================================
    public void Replace(int oldValue, int newValue)
    {
        Node? current = _head;

        while (current is not null)
        {
            if (current.Data == oldValue)
            {
                current.Data = newValue;
            }

            current = current.Next;
        }
    }

    // ================================================================
    //  PROVIDED — GetEnumerator
    //  Enables: foreach (var item in myLinkedList)
    // ================================================================
    public IEnumerable<int> GetEnumerator()
    {
        Node? current = _head;

        while (current is not null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    // ================================================================
    //  Problem 5 — Reverse                                 O(n)
    //  Enables: foreach (var item in myLinkedList.Reverse())
    // ================================================================
    public IEnumerable<int> Reverse()
    {
        Node? current = _tail;

        while (current is not null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }
}

// ================================================================
//  Extension method — AsString()
//  Used by tests: myLinkedList.GetEnumerator().AsString()
// ================================================================
public static class IntEnumerableExtensions
{
    public static string AsString(this IEnumerable<int> source)
    {
        return "<LinkedList>{" + string.Join(", ", source) + "}";
    }
}
