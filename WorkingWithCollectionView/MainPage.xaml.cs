using BindingToObject.Models;
using System.Collections.ObjectModel;

namespace WorkingWithCollectionView;

public partial class MainPage : ContentPage
{
    //אוסף התלמידים
    public ObservableCollection<Student> Students { get; set; }

    #region כדי שהמסך יתעדכן כתוצאה מעדכון נתון עלינו להפעיל את אירוע בכל שינוי ערך שלו. לכן עלינו ליצור שדות מגבה
   
    private Student _student;//תלמיד נבחר
    #endregion

    #region בכל שינוי בשדות נפעיל את האירוע
    public Student Student { get => _student; set { if (_student != value) { _student = value; OnPropertyChanged("Student"); } } }

    #endregion
    public Student current;

    public MainPage()
    {
        //נגדיר רשימה ריקה
        Students = new ObservableCollection<Student>();
        //נאתחל את התלמיד הבודד לריק
        Student = new() { Image="dotnet_bot.svg", Name="ברירת מחדל",BirthDate=new DateTime()};
        current = null;
       
        //נקשר את הדף שלנו לאובייקט המכיל את הקוד שלו
        this.BindingContext = this;
        InitializeComponent();
       
	}

    /// <summary>
    /// פעולה הטוענת את נתוני התלמידים 
    /// מכיוון ש
    /// Students הוא ObeservableCollection
    /// הפקד המקושר יתעדכן אוטומטית
    /// </summary>
    private void LoadStudents()
    {
        this.Students.Clear();
       //דוגמה להוספת תלמיד בעקבות השינוי של גרסא 6 - אין צורך לציין אחרי
       //new שם מחלקה
        Students.Add(new() { Name = "Roni", Image = "roni.jpg", BirthDate = new DateTime(2006, 2, 19) });
        //הוספת תלמיד בדרך המלאה
        Students.Add(new Student { Name = "Omer", BirthDate = new DateTime(2006, 2, 9), Image = "omer.jpg" });
        //כל התאריכים ששמתי נכונים בטווח של פלוס מינוס 2 שנים
        Students.Add(new Student { Name = "Avital", BirthDate = new DateTime(2006, 7, 13), Image = "avital.jpg" });
        Students.Add(new Student { Name = "Avigdor", BirthDate = new DateTime(2006, 4, 18), Image = "aviv.jpg" });
        Students.Add(new Student { Name = "Gil", BirthDate = new DateTime(2006, 9, 22), Image = "gil.jpg" });
        Students.Add(new Student { Name = "Itamar", BirthDate = new DateTime(2006, 8, 19), Image = "itamar.jpg" });
        Students.Add(new Student { Name = "Jofir", BirthDate = new DateTime(2006, 4, 20), Image = "jofir.jpg" });
        Students.Add(new Student { Name = "Maya", BirthDate = new DateTime(2006, 10, 25), Image = "maya.jpg" });
        Students.Add(new Student { Name = "Ofek", BirthDate = new DateTime(2006, 6, 28), Image = "ofek.jpg" });
        Students.Add(new Student { Name = "OfekMan", BirthDate = new DateTime(2006, 3, 14), Image = "ofekman.jpg" });
        Students.Add(new Student { Name = "Yali", BirthDate = new DateTime(2006, 9, 12), Image = "yali.jpg" });
        Student = Students[0];
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        LoadStudents();
        OnPropertyChanged(nameof(Students));

    }
    private void ButtonDel_Clicked(object sender, EventArgs e)
    {
        this.Students.Clear();
        OnPropertyChanged(nameof(Students));

    }
    private void SwipeL_Clicked(object sender, EventArgs e)
    {
        Students.Remove(current);
        OnPropertyChanged(nameof(Students));
    }
    private void SwipeR_Clicked(object sender, EventArgs e)
    {
        Students.Add(current);
        OnPropertyChanged(nameof(Students));
    }
    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        current = e.CurrentSelection as Student;
    }
}

