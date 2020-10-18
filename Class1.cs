using System;
using System.Collections.Generic;


class AddressBook
{
    List<Address> addresses;

    public AddressBook()
    {
        addresses = new List<Address >();
    }
    /// <summary>
    /// It will check for duplicates and adds the contatct to address book
    /// </summary>
    /// <param name="Firstname"></param>
    /// <param name="Lastname"></param>
    /// <param name="address"></param>
    /// <param name="city"></param>
    /// <param name="state"></param>
    /// <param name="zip"></param>
    /// <param name="phoneNo"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    public bool add(string Firstname, string Lastname, string address, string city, string state, int zip, double phoneNo, string email)
    {
        Address  addr = new Address (Firstname, Lastname,address,city,state,zip,phoneNo,email);
        Address  result = find(Firstname);

        if (result == null)
        {
            addresses.Add(addr);
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// it is useful for searching and delete the contact
    /// </summary>
    /// <param name="Firstname"></param>
    /// <returns></returns>
    public bool remove(string Firstname)
    {
        Address  addr = find(Firstname);

        if (addr != null)
        {
            addresses.Remove(addr);
            return true;
        }
        else
        {
            return false;
        }
    }
    /// <summary>
    /// Displaying the Contacts
    /// </summary>
    /// <param name="action"></param>
    public void list(Action<Address > action)
    {
        addresses.ForEach(action);
    }

    public bool isEmpty()
    {
        return (addresses.Count == 0);
    }
    /// <summary>
    /// Finds the string with the First Name for Editing the details
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Address  find(string name)
    {
        Address  addr = addresses.Find((a) => a.Firstname == name);
        return addr;
    }
}