using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using AddressBook.WindowsForms.Models;

namespace AddressBook.WindowsForms
{
    public partial class Form1 : Form
    {

        public List<Contact> contacts;
        public Contact selectedContact;

        public Form1()
        {
            InitializeComponent();

            LoadContacts();
            ConfigureView();
        }

        private void ConfigureView()
        {
            Text = "Address Book";

            listBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Top;

            RefreshContactList();
        }

        private void RefreshContactList()
        {
            listBox1.Items.Clear();

            foreach (Contact contact in contacts) listBox1.Items.Add(contact.Name);
        }

        private void SaveContacts()
        {
            //create the json file asynchronously
            string fileName = "contacts.json";
            string jsonString = JsonSerializer.Serialize(contacts);
            File.WriteAllText(fileName, jsonString);
        }

        private void LoadContacts()
        {
            if (File.Exists("contacts.json") == false)
            {
                // there are no saved contacts, create some sample data
                if (contacts == null)
                    contacts = new List<Contact>();
                else
                    contacts.Clear();

                contacts.Add(new Contact {Name = "Montgomery Burns ", Telephone = "", Notes = ""});
                contacts.Add(new Contact {Name = "Ned Flanders", Telephone = "", Notes = ""});
                contacts.Add(new Contact {Name = "Edna Krabappel", Telephone = "", Notes = ""});
                contacts.Add(new Contact {Name = "Moe Szyzlak", Telephone = "", Notes = ""});
                contacts.Add(new Contact {Name = "Luann Van Houten", Telephone = "", Notes = ""});
                contacts.Add(new Contact {Name = "Lenny Leonard", Telephone = "", Notes = ""});
                contacts.Add(new Contact {Name = "Helen Lovejoy", Telephone = "", Notes = ""});
                contacts.Add(new Contact {Name = "Kent Brockman", Telephone = "", Notes = ""});

                SaveContacts();
            }
            else
            {
                // load the existing file:
                string fileName = "contacts.json";
                string jsonString = File.ReadAllText(fileName);
                contacts = JsonSerializer.Deserialize<List<Contact>>(jsonString);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedContact = contacts[listBox1.SelectedIndex];
            txtName.Text = selectedContact.Name;
            txtTelephone.Text = selectedContact.Telephone;
            txtNotes.Text = selectedContact.Notes;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            selectedContact.Name = txtName.Text;
            selectedContact.Telephone = txtTelephone.Text;
            selectedContact.Notes = txtNotes.Text;

            SaveContacts();
        }
    }
}