using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace PrincessBrideTrivia.Tests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void LoadQuestions_RetrievesQuestionsFromFile()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                // Arrange
                GenerateQuestionsFile(filePath, 2);

                // Act
                Question[] questions = Program.LoadQuestions(filePath);

                // Assert 
                Assert.AreEqual(2, questions.Length);
            }
            finally
            {
                File.Delete(filePath);
            }
        }

        [TestMethod]
        [DataRow("1", true)]
        [DataRow("2", false)]
        public void DisplayResult_ReturnsTrueIfCorrect(string userGuess, bool expectedResult)
        {
            // Arrange
            Question question = new Question();
            question.CorrectAnswerIndex = "1";

            // Act
            bool displayResult = Program.DisplayResult(userGuess, question);

            // Assert
            Assert.AreEqual(expectedResult, displayResult);
        }

        [TestMethod]
        public void GetFilePath_ReturnsFileThatExists()
        {
            // Arrange

            // Act
            string filePath = Program.GetFilePath();

            // Assert
            Assert.IsTrue(File.Exists(filePath));
        }

        [TestMethod]
        [DataRow(1, 1, "100%")]
        [DataRow(5, 10, "50%")]
        [DataRow(1, 10, "10%")]
        [DataRow(0, 10, "0%")]
        public void GetPercentCorrect_ReturnsExpectedPercentage(int numberOfCorrectGuesses,
            int numberOfQuestions, string expectedString)
        {
            // Arrange

            // Act
            string percentage = Program.GetPercentCorrect(numberOfCorrectGuesses, numberOfQuestions);

            // Assert
            Assert.AreEqual(expectedString, percentage);
        }

        [TestMethod]
        public void ShuffleQuestions_ConfirmRandomQuestionOrder_Success()
        {
            //Arrange
            string filePath = Program.GetFilePath();

            //Act
            Question[] newQuestionSet = Program.LoadQuestions(filePath);
            Question[] questions = Program.LoadQuestions(filePath);

            bool flagSomethingChanged = false;
            for (int i = 0; i < newQuestionSet.Length - 1; i++) {
                if (!newQuestionSet[i].Equals(questions[i]))
                {
                    flagSomethingChanged = true;
                }
            }

            //Assert
            Assert.IsTrue(flagSomethingChanged);
        }

        [TestMethod]
        public void SwapElements_ConfirmElementsSwap_Success()
        {
            //Arrange
            int[] questionArray = {2, 4, 6, 8, 10}; //random int array for testing swapping function


            ////Act
            Program.SwapElements(questionArray, 1, 3);


            //Assert
            //CONFIRMING SWITCH
            Assert.IsTrue(questionArray[3].Equals(4));  //tests if original index 3 has value from index 1
            Assert.IsTrue(questionArray[1].Equals(8));  //tests if original index 3 is moved to index 1

            //confirming that in between indices are untouched. 
            Assert.IsTrue(questionArray[2].Equals(6));  //testing an unswapped member 
            Assert.IsFalse(questionArray[1].Equals(4)); //tests old index position

           


        }

        private static void GenerateQuestionsFile(string filePath, int numberOfQuestions)
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                string[] lines = new string[5];
                lines[0] = "Question " + i + " this is the question text";
                lines[1] = "Answer 1";
                lines[2] = "Answer 2";
                lines[3] = "Answer 3";
                lines[4] = "2";
                File.AppendAllLines(filePath, lines);
            }
        }
    }
}
