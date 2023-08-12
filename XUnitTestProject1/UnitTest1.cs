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
            //����� ����������� ���� ���
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
            //����� ������������ ����� ������ ����
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
            //����� ������������ ����� ������ ����
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
            //����� �������
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
            // ; - ���������� � ����������� ���� ���� �����
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
            //����� � �������� ����� 
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
            // ����� ����� ����������� � �������
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
            // ����� ����� ����������� ��� ����� �� �������� �� ����� ���� ���� ���
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
            // ����� ����� ����������� ��� ����� �� ����� ������ ����
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
            // ����� �� ����� (��� ';') �����������
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
            // ��������, ��� �������� �� ���� null, ���� �������� ������� ���������
            string text = "int key = 20";
            string oldname = "key";
            string newname = "num";

            Assert.NotNull(ConsoleApp1.VariableRename.rename(text, oldname, newname));
        }

        [Fact]
        public void Test11()
        {
            // VarNameVariableRenameObjIsNotNullTest
            // ��������, ��� ��������� ���� �� ��� null
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
cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b; 
if(b>0) 
S=a/b; 
if(b>0) 
P=pow(a,2)/pow(b,3);";
            string method = @"cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b;";
            string name = "area";

            string expected = @"void area()
{cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
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
            // ��� ���� ������� � ����� ������ 
            string text = @"area(); 
int a; 
int b; 
int A; 
cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b; 
A=a*b";
            string method = @" 
cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b;";
            string name = "area";

            string expected = @"area(); 
int a; 
int b; 
int A; 
cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b; 
A=a*b";

            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test14()
        {
            // ������� ���� ����������� ��������� �������� 
            string text = @"int a; 
int b; 
int A; 
float A2; 
cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b; 
A=a*b; 
cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b; 
A2=a/b;";
            string method = @"cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b;";
            string name = "area";

            string expected = @"void area()
{cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
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
            // ������� ���� ����������� ��������� ��������, � ������ � ��� ����� ����� �������������� 
            string text = @"int a; 
int b; 
int A; 
float A2; 
cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b; 
A=a*b; 
//cout << ""������ �������� �: ""; 
//cin >> a; 
//cout << ""������ �������� b: ""; 
//cin >> b; 
A2=a/b;";
            string method = @"cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b;";
            string name = "area";

            string expected = @"void area()
{cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b;}
int a; 
int b; 
int A; 
float A2; 
area(); 
A=a*b; 
//cout << ""������ �������� �: ""; 
//cin >> a; 
//cout << ""������ �������� b: ""; 
//cin >> b; 
A2=a/b;";
            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test16()
        {
            // ������� ���� ����������� ��������� ��������, ���� � ��� �������������� 
            string text = @"int a; 
int b; 
int A; 
float A2; 
cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b; 
A=a*b; 
/*cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b;*/ 
A2=a/b;";
            string method = @"cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b;";
            string name = "area";

            string expected = @"void area()
{cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b;}
int a; 
int b; 
int A; 
float A2; 
area(); 
A=a*b; 
/*cout << ""������ �������� �: ""; 
cin >> a; 
cout << ""������ �������� b: ""; 
cin >> b;*/ 
A2=a/b;";
            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test17()
        {
            //�������� ����� �� �� ������������� ������ 
            string text = @"void calculations() 
{cout << ""�������� ����������""; 
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
cout << ""���������� ���� ���������, ��������� ���������""}";
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
{cout << ""�������� ����������""; 
result_type(); 
cout << ""���������� ���� ���������, ��������� ���������""}";
            var result = ConsoleApp1.MethodExtraction.ExtractMethod(text, method, name);

            Assert.Equal(expected, result);
        }


        [Fact]
        public void Test18()
        {
            // MethodExtractionObjIsNotNullTest
            // ��������, ��� ��������� ���� �� ��� null
            ConsoleApp1.MethodExtraction MethodExtraction = new ConsoleApp1.MethodExtraction();
            Assert.NotNull(MethodExtraction);
        }

        [Fact]
        public void Test19()
        {
            // ExtractMethodResultIsNotNullIfParamsAreNullTest
            // ��������, ��� �������� �� ���� null, ���� �������� �� ��������� � ���������� null
            Assert.NotNull(ConsoleApp1.MethodExtraction.ExtractMethod(null, null, null));
        }

        [Fact]
        public void Test20()
        {
            // ����� ������� �������
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