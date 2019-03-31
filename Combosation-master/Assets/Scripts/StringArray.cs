using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringArray : MonoBehaviour {
	public Text QuestionDisplay;
	public Text AnswerDisplay;
	public int TimeToSwitch;
	public bool AnsweredRight;
	public string[] questions; //the array of questions
	public string currentQuestion; //the current question being displayed
	public int currentQuestionIndex; //an index to keep track of what number in the question array we're on
	//I wrote the question responses as 0-5 instead of 1-6 so that they line up with their corresponding question number in the index
	string Question0Responses = "A: Breadsticks work way better, but I like where you’re going with this." +
		"\n B: I wrote a poem about how I want to be your walrus mate, now and forever, drifting in the artic sea of eternity." +
		"\nC: A walrus's core body temperature is about 97.9°F. That’s .7 degrees lower than a human’s.";
	
	string Question1Responses = "A: I mean we’re already here but uhhh… Do you think Five Guys is open right about now?" +
		"\nB: The alps of Switzerland, the canals of Venice. Or Paris, the city of love." +
		"\nC: I don’t really know, I’m strapped for cash and you don’t have a jacket\n";

	string Question2Responses = "A:Major? I barely know her!" +
		"\nB:Majors? Universities? None of those matter now, what matters is you and I in this moment." +
		"\nC:Oh, it’s game design.";

	string Question3Responses = "A: Oh man, I love those terrible live-action Scooby-Doo movies. Like, zoinks, Scoob!" +
		"\nB: I prefer romantic comedies myself." +
		"\nC: I guess, but I like all kinds of movies, really.\n";

	string Question4Responses = "A: Does Weird Al count?" +
		"\nB: No poetry can compare to a night like tonight. But if I had to choose, Shakespeare." +
		"\nC: I feel like Dr. Seuss is a safe option here. \n";

	string Question5Responses = "A: I only brought monopoly money." +
		"\nB: I shall pay, for I would do anything for you, darling." +
		"\nC: Yeah, sure! Going Dutch only seems fair.\n";
	// Use this for initialization
	void Start () {
		currentQuestionIndex = 0;
		AnsweredRight = false;
	}
	
	// Update is called once per frame
	void Update () {
		currentQuestion = questions [currentQuestionIndex]; //the current question is whichever string in the "questions" array matches the number in the currentQuestionIndex
		//if (currentQuestion == questions [0]) {
			//A is the correct response
			//if(Input.GetKey(key
		//}
	}
}
