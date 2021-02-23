using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkLibraryApp
{
    public partial class Form1 : Form
    {
        private LibraryEntities entities;
        public Form1()
        {
            InitializeComponent();
            entities = new LibraryEntities();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getAllBooks();
            getAllAuthors();
            getAllCountries();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                label1.Text = "К-сть сторінок:";
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                label1.Text = "Перша літера:";
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                panel1.Visible = true;
                panel2.Visible = true;
                label1.Text = "Ім'я автора:";
                label2.Text = "Прізвище:";
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                label1.Text = "Країна автора:";
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                label1.Text = "N символів:";
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                panel1.Visible = true;
                panel2.Visible = false;
                label1.Text = "Країна автора:";
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
        private void doMethodBtn_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked)
            {
                int pages = int.Parse(textBox1.Text);
                //var books = entities.method1ReturnBooks(pages).ToList();
                var books = from b in entities.method1ReturnBooks(pages).ToList()
                            select new
                            {
                                BookId = b.Id,
                                BookName = b.Name,
                                BookPages = b.Pages,
                                BookAuthorId = b.AuthorId,
                                BookAuthors = b.Authors.Name + " " + b.Authors.Surname
                            };
                booksGridView.DataSource = books.ToList();
            }
            else if (radioButton2.Checked)
            {
                string letter = textBox1.Text;
                var books = from b in entities.method2ReturnBooks(letter).ToList()
                            select new
                            {
                                BookId = b.Id,
                                BookName = b.Name,
                                BookPages = b.Pages,
                                BookAuthorId = b.AuthorId,
                                BookAuthors = b.Authors.Name + " " + b.Authors.Surname
                            };
                booksGridView.DataSource = books.ToList();
            }
            else if (radioButton3.Checked)
            {
                string name = textBox1.Text;
                string surname = textBox2.Text;
                var books = from b in entities.method3ReturnsBooks(name, surname).ToList()
                            select new
                            {
                                BookId = b.Id,
                                BookName = b.Name,
                                BookPages = b.Pages,
                                BookAuthorId = b.AuthorId,
                                BookAuthors = b.Authors.Name + " " + b.Authors.Surname
                            };
                booksGridView.DataSource = books.ToList();
            }
            else if (radioButton4.Checked)
            {
                string countryName = textBox1.Text;
                var books = from b in entities.method4ReturnBooks(countryName).ToList()
                            select new
                            {
                                BookId = b.Id,
                                BookName = b.Name,
                                BookPages = b.Pages,
                                BookAuthorId = b.AuthorId,
                                BookAuthors = b.Authors.Name + " " + b.Authors.Surname
                            };
                booksGridView.DataSource = books.ToList();

            }
            else if (radioButton5.Checked)
            {
                int bookNameCount = int.Parse(textBox1.Text);
                var books = from b in entities.method5ReturnBooks(bookNameCount).ToList()
                            select new
                            {
                                BookId = b.Id,
                                BookName = b.Name,
                                BookPages = b.Pages,
                                BookAuthorId = b.AuthorId,
                                BookAuthors = b.Authors.Name + " " + b.Authors.Surname
                            };
                booksGridView.DataSource = books.ToList();

            }
            else if (radioButton6.Checked)
            {
                string countryName = textBox1.Text;
                var books = from b in entities.method6ReturnBooks(countryName).ToList()
                            select new
                            {
                                BookId = b.Id,
                                BookName = b.Name,
                                BookPages = b.Pages,
                                BookAuthorId = b.AuthorId,
                                BookAuthors = b.Authors.Name + " " + b.Authors.Surname
                            };
                booksGridView.DataSource = books.ToList();
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            var authors = from a in entities.method7ReturnAuthor().ToList()
                          select new
                          {
                              AuthorId = a.Id,
                              AuthorName = a.Name,
                              AuthorSurname = a.Surname,
                              AuthorCountry = a.Countries.Name,
                              AuthorBookCount = a.Books.Count()
                          };
            authorsGridView.DataSource = authors.ToList();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            var countries = from c in entities.method8ReturnCountry().ToList()
                            select new
                            {
                                CountryId = c.Id,
                                CountryName = c.Name,
                                AuthorsCount = c.Authors.Count()
                            };
            countriesGridView.DataSource = countries.ToList();
        }

        private void resetAuthorsList_Click(object sender, EventArgs e)
        {
            radioButton7.Checked = false;
            getAllAuthors();
        }

        private void resetCountriesList_Click(object sender, EventArgs e)
        {
            radioButton8.Checked = false;
            getAllCountries();
        }

        private void getAllBooks()
        {
            var books = from b in entities.Books
                        select new
                        {
                            BookId = b.Id,
                            BookName = b.Name,
                            BookPages = b.Pages,
                            BookAuthorId = b.AuthorId,
                            BookAuthors = b.Authors.Name + " " + b.Authors.Surname
                        };
            booksGridView.DataSource = books.ToList();
        }
        private void getAllAuthors()
        {
            var authors = from a in entities.Authors
                          select new
                          {
                              AuthorId = a.Id,
                              AuthorName = a.Name,
                              AuthorSurname = a.Surname,
                              AuthorCountry = a.Countries.Name,
                              AuthorBookCount = a.Books.Count()
                          };
            authorsGridView.DataSource = authors.ToList();
        }
        private void getAllCountries()
        {
            var countries = from c in entities.Countries
                            select new
                            {
                                CountryId = c.Id,
                                CountryName = c.Name,
                                AuthorsCount = c.Authors.Count()
                            };
            countriesGridView.DataSource = countries.ToList();
        }

        private void resetBookListBtn_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            getAllBooks();
        }
    }
}
