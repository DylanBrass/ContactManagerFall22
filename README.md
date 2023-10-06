<h3 align="center">Contact manager with WPF</h3>

  <p align="center">
    A simple app to manage your contacts and their addresses.
  </p>
</p>

![Downloads](https://img.shields.io/github/downloads/DylanBrass/ContactManagerFall22/total) ![Contributors](https://img.shields.io/github/contributors/DylanBrass/ContactManagerFall22?color=dark-green) ![Forks](https://img.shields.io/github/forks/DylanBrass/ContactManagerFall22?style=social) ![Stargazers](https://img.shields.io/github/stars/DylanBrass/ContactManagerFall22?style=social) ![Issues](https://img.shields.io/github/issues/DylanBrass/ContactManagerFall22) 

## Table Of Contents

* [About the Project](#about-the-project)
* [Built With](#built-with)
* [Getting Started](#getting-started)
  * [Prerequisites](#prerequisites)
  * [Installation](#installation)
* [Usage](#usage)
* [Contributing](#contributing)
* [Authors](#authors)
* [Acknowledgements](#acknowledgements)

## About The Project

![Screen Shot](images/screenshot.png)

This project is a simple contact manager that was assigned to use by our teacher for our .NET class where we learned C# and WPF as well as being introduced to the Microsoft and C# ecosystem.


Requirements that were given to us : 
* You must work in your assigned teams of 2-4 people.
* You must use Git to provide version control. Send an invite as a collaborator to bwood-crc for
verification, failure to do so will result in a 0 for the project.
* The goal of this project is to create a contact manager. What is a contact manager? It is an application
that allows a user to add contacts, edit contacts, view contacts and delete contacts. We call these CRUD
(create, read, update, delete) operations.
* For viewing contacts, we will see a list of the existing contacts (contact names). When a user clicks on a
contact in the list, a new window will be displayed that shows the details of that particular contact.
o The contact data to be displayed and how it is displayed is up to you. However, it should be
relevant and logical.
* The wireframes and screen layouts are NOT provided, I want to see how far creativity and usability takes
you.

With these user interactions :
1. Your contact manager must present a summarized list of all existing contacts.
2. Your contact manager must allow a user to add a new contact.
3. Your contact manager must allow a user to view an existing contact.
4. Selection of a contact in the list of existing contacts will open a new window displaying details of that
contact.
5. You should be able to update a contact, preferably the screen should not be updatable until you click
“edit”, then you can make changes and save the record.
6. You should also be able to update the email, phone and address for your contact.
7. The contact should show a list of addresses and phone numbers on their detail page, to edit this
address, a third window should pop up showing full address details.
8. Your database functions must be all within a common database class.
9. You should be able to export a CSV file of the records in the database.

## Built With

We used ASP.NET WPF and Microsoft SQL server. The program is mostly written in C# with the front end being XAML. Of course, we used TSQL to write the scripts to create and insert data in the database to make it work for our teacher. 

## Getting Started

To get a local copy up and running follow these simple example steps.

### Prerequisites

You will need to have installed SQL Server management Studio and Microsoft Visual Studio.

This project is harder to install because of SQL Server management is a relativly hard tool to get use to, but it's quite simple to do, I will show a step by step below,

### Installation

1. Clone the project with : https://github.com/DylanBrass/ContactManagerFall22.git
2. You open it with Visual Studio
3. Next you have to open SQL Server
4. You will create a new table called FinalProjectDB:
![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/45a0c394-d05e-4432-a355-c4a3e691a4de)

![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/b169c185-ec75-4ef6-899b-d3df7c91d1fd)

![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/1cf0bdb2-824e-4fd7-9fb7-9941b33acf6c)

5. You go locate the TSQL Script found here :
   
![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/29819f1d-ac83-4b1e-8ded-6e72a90a6b5f)

6. You copy the whole script
   
7. You open a new Querry in SQL Server and paste the script

![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/335ac794-eeb4-41bd-b8b3-c04d5c32f667)

You will need to change ProjectOwner higlighted here to a login that exists on your SQL Server

![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/765071ea-0106-4a58-a34b-500ac14d8dce)

8. Then run the script
    
9. For me most of the time I had to restart my SQL Server to see the tables like so :
    
![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/90dd8b06-5245-4437-8f2c-aea17c340bff)

10. You then need to insert the Type codes with this : 
![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/92e6a5f7-23d3-4774-a3a9-2d4d9acfdac9)


11. Then you can simply run the project and look around :)
    
![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/578f04e8-a527-4fbe-bfcd-1aa4428487d5)



## Usage
![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/63cc60a1-1669-4c88-9a64-aa7ab3bf1650)

![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/94d521d8-200b-4393-b6d3-944eae31de47)


### Challenges

#### CSV Handling
```c#
public void ExportContact()
{
    try
    {
        StringBuilder csv = new StringBuilder();
        StringBuilder csvFileContact = new StringBuilder();
        SaveFileDialog saveFileDialog = new SaveFileDialog
        {
            InitialDirectory = "c:\\",
            Filter = "CSV Files (*.csv)|*.csv"
        };

        if (saveFileDialog.ShowDialog() == true)
        {


            List<Contact> contacts = db.GetContacts();

            foreach (Contact con in contacts)
            {
                PropertyInfo[] fullcon = con.GetType().GetProperties();
                foreach (PropertyInfo property in fullcon)
                {
                    csv.Append("," + property.GetValue(con, null).ToString());
                }
                csv.Remove(0, 1);
                csvFileContact.AppendLine(csv.ToString());
                csv.Clear();
            }
            File.WriteAllText(saveFileDialog.FileName, csvFileContact.ToString());
        }
    }
    catch
    {
        MessageBox.Show("File is used by another program !", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

    }
}
```
This code is what makes this button work.

![image](https://github.com/DylanBrass/ContactManagerFall22/assets/71225455/33d82518-2e9c-45bc-b075-a31e2ffa4e92)

This is very simple code that allows you to get all the contacts you have saved and transfer them to a .csv file. This feature allows for easy transport of contacts from one computer to another. But since this was my first time doing this I had to create this logic and understand it.

#### retriving images 
```c#
 Image img = new Image();
 con.Open();
 SqlCommand command = new SqlCommand("SELECT * FROM Image  WHERE Id=@Image_Id", con);
 command.Parameters.AddWithValue("@Image_Id", image_id);
 SqlDataReader sdr = command.ExecuteReader();
 while (sdr.Read())
 {
     MemoryStream ms = new MemoryStream((byte[])sdr["Image"]);
     BitmapImage imageSource = new BitmapImage();
     imageSource.BeginInit();
     imageSource.StreamSource = ms;
     imageSource.EndInit();
     img.Source = imageSource;
 }
 sdr.Close();
 return img;
```

This was really fun to do ! I found out how to store the image by turning it into a byte array by using ReadAll Bytes which is made extremely easy by C#. And to be fair even reading from the database was made easy with StreamSource, what was hard was connecting everything together since it's a relativly big project espicially for me in my second year of coding.



## Authors

* **DylanBrass** - *Comp Sci Student* - [DylanBrass](https://github.com/DylanBrass) - *Made the backend*
* ** KarinaSofia** - *Comp Sci Student* - [ KarinaSofia](https://github.com/KarinaSofia) - *Made most of the front end*
* **HennaCH** - *Comp Sci Student* - [HennaCH](https://github.com/HennaCH) - *Made small changes to front end*
