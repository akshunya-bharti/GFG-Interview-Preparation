# GFG-Interview-Preparation
My Solutions (in C#) along with the custom test cases of the problems in the GeeksForGeeks course: "Interview Preparation"

Link of the course:-
https://practice.geeksforgeeks.org/batch/Interview%20Preparation/

**To execute any particular problem:-**
1. Open src/Program.cs
2. Provide the Class name of the problem to the variable 'problem'.
3. Provide test cases in the file {classname}.txt at the same location as the class file.
4. Run (Ctrl + F5)

**Points to remember while creating test cases text file:-**
1. Provide total no of test cases (n) in first line.
2. From 2nd line onwards provide the test case in each new line.
3. After giving all the input lines write the word 'expected' in next line 
4. Provide the expected outputs for the test cases in next n lines.
<br />e.g. If you have 3 test cases for a program checking the number is even or not, your test file should look like this:-

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;7<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;11<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;expected<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yes<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;No<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;No<br />
<br />
**To add a new problem:-**<br />

A sample problem file 'Sample.cs' has been provided at src/Problems/ <br />
It is a template file which can be reused when writing a new problem class file. Follow the comments in the file to identify all the places where modification is required.
