using System;

class Address 
{
    public string Firstname;
    public string Lastname;
    public string address;
    public string city;
    public string state;
    public int zip;
    public Double phoneNo;
    public string email;

    public Address (string Firstname, string Lastname, string address, string city, string state, int zip, double phoneNo, string email)
    {
        this.Firstname = Firstname;
        this.Lastname = Lastname;
        this.address = address;
        this.city = city;
        this.state = state;
        this.zip = zip;
        this.phoneNo = phoneNo;
        this.email = email;
    }
}