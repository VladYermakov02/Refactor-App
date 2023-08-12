using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //
        // Rename Tests
        //
        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+

        [Fact]
        public void Test1()
        {
            //змінна зустрічається один раз
            string text = "int key = 20";
            string oldname = "key";
            string newname = "num";

            string expected = "int num = 20";
            var result = ConsoleApp1.VariableRename.rename(text, oldname, newname);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test2()
        {
            //змінна зустрічаються більше одного разу
            string text = @"int key;
key = 20;";
            string oldname = "key";
            string newname = "num";

            string expected = @"int num;
num = 20;";
            var result = ConsoleApp1.VariableRename.rename(text, oldname, newname);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test2_1()
        {
            //змінна зустрічаються більше одного разу
            string text = @"int key
key = 20";
            string oldname = "key";
            string newname = "num";

            string expected = @"int num
num = 20";
            var result = ConsoleApp1.VariableRename.rename(text, oldname, newname);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test3()
        {
            //змінна відсутня
            string text = "";
            string oldname = "key";
            string newname = "num";

            string expected = "";
            var result = ConsoleApp1.VariableRename.rename(text, oldname, newname);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test4()
        {
            // ; - ігнорується і перейменовує лише саму змінну
            string text = "int key;";
            string oldname = "key";
            string newname = "num";

            string expected = "int num;";
            var result = ConsoleApp1.VariableRename.rename(text, oldname, newname);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test5()
        {
            //змінна є частиною назви 
            string text = "bool key_taken;";
            string oldname = "key";
            string newname = "num";

            string expected = "bool key_taken;";
            var result = ConsoleApp1.VariableRename.rename(text, oldname, newname);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test6()
        {
            // назва змінної зустрічається в строчці
            string text = @"string str=""key"";";
            string oldname = "key";
            string newname = "num";

            string expected = text;
            var result = ConsoleApp1.VariableRename.rename(text, oldname, newname);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test7()
        {
            // назва змінної зустрічається при виводі її значення на екран лише один раз
            string text = "cout << \"Value of variable key is: \";";
            string oldname = "key";
            string newname = "num";

            string expected = text;
            var result = ConsoleApp1.VariableRename.rename(text, oldname, newname);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test8()
        {
            // назва змінної зустрічається при виводі на екран багато разів
            string text = @"cout << ""Variable key represents : "";
                cout << ""Value of variable key is: "";";
            string oldname = "key";
            string newname = "num";

            string expected = text;
            var result = ConsoleApp1.VariableRename.rename(text, oldname, newname);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test9()
        {
            // цифри та знаки (крім ';') ігноруються
            string text = "int 1key_;";
            string oldname = "1key_";
            string newname = "num";

            string expected = "int num;";
            var result = ConsoleApp1.VariableRename.rename(text, oldname, newname);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test10()
        {
            // NewVarNameIsNotNullTest
            // перевіряє, щоб значення не було null, якщо передати коректні аргументи
            string text = "int key = 20";
            string oldname = "key";
            string newname = "num";

            Assert.NotNull(ConsoleApp1.VariableRename.rename(text, oldname, newname));
        }

        [Fact]
        public void Test11()
        {
            // VarNameVariableRenameObjIsNotNullTest
            // перевіряє, щоб створений клас не був null
            ConsoleApp1.VariableRename varNameVariableRename = new ConsoleApp1.VariableRename();
            Assert.NotNull(varNameVariableRename);
        }
                
        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+
        //
        // Extraction Tests
        //
        //-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+

        [Fact]
        public void Test12()
        {

            string text = @"int a;
int b; 
double S; 
double P; 
cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b; 
if(b>0) 
S=a/b; 
if(b>0) 
P=pow(a,2)/pow(b,3);";
            string method = @"cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;";
            string name = "area";

            string expected = @"void area()
{cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;}
int a;
int b; 
double S; 
double P; 
area(); 
if(b>0) 
S=a/b; 
if(b>0) 
P=pow(a,2)/pow(b,3);";
            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test13()
        {
            // вже існує функція з такою назвою 
            string text = @"area(); 
int a; 
int b; 
int A; 
cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b; 
A=a*b";
            string method = @" 
cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;";
            string name = "area";

            string expected = @"area(); 
int a; 
int b; 
int A; 
cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b; 
A=a*b";

            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test14()
        {
            // декілька разів зустрічається однаковий фрагмент 
            string text = @"int a; 
int b; 
int A; 
float A2; 
cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b; 
A=a*b; 
cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b; 
A2=a/b;";
            string method = @"cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;";
            string name = "area";

            string expected = @"void area()
{cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;}
int a; 
int b; 
int A; 
float A2; 
area(); 
A=a*b; 
area(); 
A2=a/b;";
            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test15()
        {
            // декілька разів зустрічається однаковий фрагмент, в одному з них кожен рядок закоментований 
            string text = @"int a; 
int b; 
int A; 
float A2; 
cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b; 
A=a*b; 
//cout << ""Введіть значення а: ""; 
//cin >> a; 
//cout << ""Введіть значення b: ""; 
//cin >> b; 
A2=a/b;";
            string method = @"cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;";
            string name = "area";

            string expected = @"void area()
{cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;}
int a; 
int b; 
int A; 
float A2; 
area(); 
A=a*b; 
//cout << ""Введіть значення а: ""; 
//cin >> a; 
//cout << ""Введіть значення b: ""; 
//cin >> b; 
A2=a/b;";
            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test16()
        {
            // декілька разів зустрічається однаковий фрагмент, один з них закоментований 
            string text = @"int a; 
int b; 
int A; 
float A2; 
cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b; 
A=a*b; 
/*cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;*/ 
A2=a/b;";
            string method = @"cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;";
            string name = "area";

            string expected = @"void area()
{cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;}
int a; 
int b; 
int A; 
float A2; 
area(); 
A=a*b; 
/*cout << ""Введіть значення а: ""; 
cin >> a; 
cout << ""Введіть значення b: ""; 
cin >> b;*/ 
A2=a/b;";
            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test17()
        {
            //виділений метод не має неоголошенних змінних 
            string text = @"void calculations() 
{cout << ""Виконуємо розрахунки""; 
int a = -2; 
int b = 10; 
int result; 
int type; 
result = a - b; 
if (result < 0) 
{type = -1;} 
else if( result > 0) 
{type = 1;} 
else type = 0; 
cout << ""Розрахунки було проведено, результат перевірено""}";
            string method = @"int a = -2; 
int b = 10; 
int result; 
int type; 
result = a - b; 
if (result < 0) 
{type = -1;} 
else if( result > 0) 
{type = 1;} 
else type = 0;";
            string name = "result_type";

            string expected = @"void result_type()
{int a = -2; 
int b = 10; 
int result; 
int type; 
result = a - b; 
if (result < 0) 
{type = -1;} 
else if( result > 0) 
{type = 1;} 
else type = 0;}
void calculations() 
{cout << ""Виконуємо розрахунки""; 
result_type(); 
cout << ""Розрахунки було проведено, результат перевірено""}";
            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void Test18()
        {
            // MethodExtractionObjIsNotNullTest
            // перевіряє, щоб створений клас не був null
            ConsoleApp1.MethodExtraction MethodExtraction = new ConsoleApp1.MethodExtraction();
            Assert.NotNull(MethodExtraction);
        }

        [Fact]
        public void Test19()
        {
            // ExtractMethodResultIsNotNullIfParamsAreNullTest
            // перевіряє, щоб значення не було null, якщо передати всі аргументи зі значеннями null
            Assert.NotNull(ConsoleApp1.MethodExtraction.ExtractMethod(null, null, null));
        }

        [Fact]
        public void Test20()
        {
            // самий простий приклад
            string text = "int main(){int num = 20;string srt = \"some srting\";}";
            string method = "int num = 20;";
            string name = "varInit";

            string expected = @"void varInit()
{int num = 20;}
int main(){varInit();string srt = ""some srting"";}";
            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }
    }
}