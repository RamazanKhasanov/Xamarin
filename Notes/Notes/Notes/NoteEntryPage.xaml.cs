using System;
using System.IO;
using System.Collections.Generic;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class NoteEntryPage : ContentPage
    {
        Note t;
        public NoteEntryPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (string.IsNullOrWhiteSpace(note.Filename))
            {
                // Save
                var filename = Path.Combine(App.FolderPath, $".notes.txt");
                File.WriteAllText(filename, note.Text);
            }
            else
            {
                // Update
                File.WriteAllText(note.Filename, note.Text);
            }
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            if (File.Exists(note.Filename))
            {
                File.Delete(note.Filename);
            }
            await Navigation.PopAsync();

        }

        async void OnCombineButtonClicked(object sender, EventArgs e)  // Обработчик нажатия на кнопку Combine
        {
            var note = (Note)BindingContext;  // Cохранение в переменной текущего объекта Note
            var notes = new List<Note>();     // Создание списка объектов Note
            var files = Directory.EnumerateFiles(App.FolderPath, "*.notes.txt");  // Сохранение в переменной списка файлов заметок
            foreach (var filename in files) // Цикл, для извлечения и сохранения заметок из файлов с список notes
            {
                if (filename != note.Filename)
                {
                    notes.Add(new Note
                    {
                        Filename = filename,
                        Text = File.ReadAllText(filename),
                        Date = File.GetCreationTime(filename)
                    });
                }
            }
            listView.ItemsSource = notes;    // Вывод на дисплей списка из заметок
        }

        async void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)  // Обработчик выбора элемента из списка ListView
        {
            var note = (Note)BindingContext; //  Сохранение в переменной текущего объекта Note
            t = e.SelectedItem as Note;     // Сохранение в переменной объекта Note, выбранного из списка
            note.Text += t.Text;     // Слияние текста исходной заметки с выбранной из списка
            File.WriteAllText(note.Filename, note.Text);    // Сохранение измененной заметки в файле
            File.Delete(t.Filename);       // Удаление выбранной заметки после слияния
            await Navigation.PopAsync();   // Вовзрат на главную страницу
        }
    }
}