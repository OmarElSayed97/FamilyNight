using System;using System.Collections.Generic;
using UnityEngine;
using Action = Structs.Action;
using Dialogue = Structs.Dialogue;
using State = Structs.State;
using ActionsNames = Structs.ActionsNames;
using Act = Structs.Act;


public class GameInitializer : MonoBehaviour
{
    public static List<Action> l_Act_Entrance;
    public static List<Action> l_Act_Sarah;
    public static List<Action> l_Act_Noah;
    public static List<Action> l_Act_Elevator;
    public static List<Action> l_Act_Finale;
   
    
    public List<Dialogue> l_WonderingD;
    public List<Dialogue> l_SarahVoiceD;


    public List<Dialogue> l_enteringNoahRoomD;
    public List<Dialogue> l_seeOrigamiD;
    public List<Dialogue> l_blamingD;
    public List<Dialogue> l_chooseNoahOnlyD;
    public List<Dialogue> l_chooseSarahOnlyD;
    public List<Dialogue> l_PlayRPSD;
    public List<Dialogue> l_ChooseRockD;
    public List<Dialogue> l_ChoosePaperD;
    public List<Dialogue> l_ChooseScissorD;
    public List<Dialogue> l_LeaveNoahRoomD;

    public List<Dialogue> l_SeeBedD;
    public List<Dialogue> l_SeePosterD;
    public List<Dialogue> l_SeeSarahD;
    public List<Dialogue> l_LeaveRoomWithSarah;
    public List<Dialogue> l_LeaveRoomWithOutSarah;
    public List<Dialogue> l_TalkToUnknownWithChild;
    public List<Dialogue> l_TalkToUnknownWithOutChild;
    public List<Dialogue> l_SeesUknownCharacter;



    [SerializeField]
    private Sprite img_Daugther;
    [SerializeField]
    private Sprite img_Daugther_Good;
    [SerializeField]
    private Sprite img_Son;
    [SerializeField]
    private Sprite img_Son_Good;
    [SerializeField]
    private Sprite img_Father;
    [SerializeField]
    private Sprite img_Father_Angry;
    [SerializeField]
    private Sprite img_UnknownCharacter;

    public static State StateInstance;

    
    private void InitializeActions()
    {       
        Action a_Wondering = new Action(ActionsNames.WONDERING, l_WonderingD);
        Action a_ListenSarahVoice = new Action(ActionsNames.LISTEN_SARAH_VOICE, l_SarahVoiceD);

        Action a_SeeBed = new Action(ActionsNames.SEE_BED,l_SeeBedD);
        Action a_SeePotser = new Action(ActionsNames.SEE_POSTER, l_SeePosterD);
        Action a_SeeSarah = new Action(ActionsNames.SEE_SARAH, l_SeeSarahD);
        Action a_TakeDecisionSarah = new Action(ActionsNames.TAKE_DECISION_SARAH);
        Action a_LeaveRoomWithSarah = new Action(ActionsNames.LEAVE_ROOM_WITH_SARAH, l_LeaveRoomWithSarah);
        Action a_LeaveRoomWithOutSarah = new Action(ActionsNames.LEAVE_ROOM_WITH_OUT_SARAH, l_LeaveRoomWithOutSarah);

        Action a_SeeNoah = new Action(ActionsNames.SEE_NOAH, l_enteringNoahRoomD);
        Action a_SeeOrigami = new Action(ActionsNames.SEE_ORIGAMI, l_seeOrigamiD);
        Action a_NoahBlameFather = new Action(ActionsNames.NOAH_BLAME_FATHER, l_blamingD);
  //      Action a_TakeDecisionNoah = new Action(ActionsNames.TAKE_DECISION_NOAH);
        Action a_chooseNoahOnly = new Action(ActionsNames.CHOOSE_NOAH_ONLY, l_chooseNoahOnlyD);
        Action a_chooseSarahOnly = new Action(ActionsNames.CHOOSE_SARAH_ONLY , l_chooseSarahOnlyD);
        Action a_chooseRPS = new Action(ActionsNames.PLAY_RPSD ,l_PlayRPSD);
        Action a_chooseRock = new Action(ActionsNames.CHOOSE_ROCK , l_ChooseRockD);
        Action a_choosePaper = new Action(ActionsNames.CHOOSE_PAPER , l_ChoosePaperD);
        Action a_chooseScissor = new Action(ActionsNames.CHOOSE_SCISSOR , l_ChooseScissorD);
        Action a_LeaveRoomNoah = new Action(ActionsNames.LEAVE_ROOM_NOAH,l_LeaveNoahRoomD);

        Action a_TalkToUnknownWithChild = new Action(ActionsNames.TALK_UNKNOWN_CHARACTER_WITH_CHILD,l_TalkToUnknownWithChild);
        Action a_TalkToUnknownWithOutChild = new Action(ActionsNames.TALK_UNKNOWN_CHARACTER_WITH_OUT_CHILD, l_TalkToUnknownWithOutChild);
        Action a_GoElevator = new Action(ActionsNames.GO_ELEVATOR);
        Action a_GoesRightFloor = new Action(ActionsNames.GOES_RIGHT_FLOOR);
        Action a_GoesWrongFloor = new Action(ActionsNames.GOES_WRONG_FLOOR);

        Action a_SeesUknownCharacter = new Action(ActionsNames.SEES_UNKNOWN_CHARACTER, l_SeesUknownCharacter);

        l_Act_Entrance.Add(a_Wondering);
        l_Act_Entrance.Add(a_ListenSarahVoice);

        l_Act_Sarah.Add(a_SeeBed);
        l_Act_Sarah.Add(a_SeePotser);
        l_Act_Sarah.Add(a_SeeSarah);
        l_Act_Sarah.Add(a_TakeDecisionSarah);
        l_Act_Sarah.Add(a_LeaveRoomWithSarah);
        l_Act_Sarah.Add(a_LeaveRoomWithOutSarah);

        l_Act_Noah.Add(a_SeeNoah);
        l_Act_Noah.Add(a_SeeOrigami);
        l_Act_Noah.Add(a_NoahBlameFather);
        l_Act_Noah.Add(a_chooseNoahOnly);
        l_Act_Noah.Add(a_chooseSarahOnly);
        l_Act_Noah.Add(a_chooseRPS);
        l_Act_Noah.Add(a_chooseRock);
        l_Act_Noah.Add(a_choosePaper);
        l_Act_Noah.Add(a_chooseScissor);
        l_Act_Noah.Add(a_LeaveRoomNoah);

       l_Act_Elevator.Add(a_TalkToUnknownWithChild);
       l_Act_Elevator.Add(a_TalkToUnknownWithOutChild);
       l_Act_Elevator.Add(a_GoElevator);
       l_Act_Elevator.Add(a_GoesRightFloor);
       l_Act_Elevator.Add(a_GoesWrongFloor);

        l_Act_Finale.Add(a_SeesUknownCharacter);         
    }

    private void InitializeDialogues()
    {
        l_WonderingD = new List<Dialogue>();
        l_SarahVoiceD = new List<Dialogue>();




        
        l_SeeBedD = new List<Dialogue>();
        l_SeePosterD = new List<Dialogue>();
        l_SeeSarahD = new List<Dialogue>();
        l_LeaveRoomWithSarah = new List<Dialogue>();
        l_LeaveRoomWithOutSarah = new List<Dialogue>();
        
        l_TalkToUnknownWithChild = new List<Dialogue>();
        l_TalkToUnknownWithOutChild = new List<Dialogue>();

        l_SeesUknownCharacter = new List<Dialogue>();
       
        

        Dialogue d_Wondering1 = new Dialogue("Honey I'm home! Dinner better be ready\nI'm STARVING!", img_Father_Angry);
        Dialogue d_Wondering2 = new Dialogue("Why is it so quiet?\nSarah...... , Noah.......", img_Father_Angry);
        Dialogue d_Wondering3 = new Dialogue("Guys!! Where are you?!\nYou better show up RIGHT NOW!", img_Father_Angry);

        Dialogue d_SarahVoice1 = new Dialogue("Sarah??!", img_Father);
        Dialogue d_SarahVoice2 = new Dialogue("Is that you?? \nThis Laugh sounded really creepy (Thinking)", img_Father);
        
        Dialogue d_SeeBed = new Dialogue("Oh my god!!! \nShe's not in her bed", img_Father);
        Dialogue d_SeePoster = new Dialogue("What are these?", img_Father);
        Dialogue d_SeeSarah1 = new Dialogue("Sarah!!\nYou freaked me out, are you okay?\nWhat are you doing in the corner over there?????", img_Father);
        Dialogue d_SeeSarah2 = new Dialogue("Nothing is real! All was a lie, I have to end this", img_Daugther);
        Dialogue d_SeeSarah3 = new Dialogue("What are you talking about?\nBaby please come down listen to your daddy", img_Father);
        Dialogue d_SeeSarah4 = new Dialogue("How can I know that, the man told me everything was a lie.", img_Daugther);
        Dialogue d_SeeSarah5 = new Dialogue("No honey, I am your dad, now listen to me and come here.", img_Father);
        Dialogue d_SeeSarah6 = new Dialogue("If you are my dad? prove it to me, What is my favorite movie?", img_Daugther);
        Dialogue d_SeeSarah7 = new Dialogue("OH MY GOD SHE IS GONNA KILL HERSELF!!\nHow should I know this there must be a clue in the room.", img_Father);
        Dialogue d_LeaveRoomWithSarah1 = new Dialogue("Dad?\nWhat happened? I don't remember anything!", img_Daugther_Good);
        Dialogue d_LeaveRoomWithSarah2 = new Dialogue("Thanks God,\nYou are FINALLY BACK\nLets Go find your brother", img_Father);
        Dialogue d_LeaveRoomWithOutSarah1 = new Dialogue("You are wrong, he was right you are not my dad, I will end this now!!!", img_Father_Angry);
        Dialogue d_LeaveRoomWithOutSarah2 = new Dialogue("SARAAAAAAAAAH!!!\n OH MY GOD, OH MY GOD WHAT JUST HAPPENED?!\nNOAH.....WHERE IS NOAH I SHOULD FIND HIM NOW AND GET OUT OF HERE", img_Father);

        Dialogue d_TalkToUnknownWithChild1 = new Dialogue("Hey Smith...!",img_UnknownCharacter);
        Dialogue d_TalkToUnknownWithChild2 = new Dialogue("Good Job, so far\nDo you want to join me and Helen? HAHAHAHA",img_UnknownCharacter);
        Dialogue d_TalkToUnknownWithChild3 = new Dialogue("Uhhhh??? \nWho's that, WHERE ARE YOU?????????",img_Father_Angry);
        Dialogue d_TalkToUnknownWithChild4 = new Dialogue("I told you I'm with your wife HAHAHAHAH\nCome and join us in the first floor\nBut hurry up cause my hands are really slippery and I am afraid I pull the trigger accidentally HAHAHAH",img_UnknownCharacter);
        Dialogue d_TalkToUnknownWithChild5 = new Dialogue("Why whould he tell me about his place? he must be deceiving me, He know I would go to Helen's room in the first floor so he must be at the basement\nOr maybe he knows that I would think that way! ", img_Father_Angry);
        Dialogue d_TalkToUnknownWithOutChild1 = new Dialogue("Heyyy You!",img_UnknownCharacter);
        Dialogue d_TalkToUnknownWithOutChild2 = new Dialogue("Did you wonder where is your wife??",img_UnknownCharacter);
        Dialogue d_TalkToUnknownWithOutChild3 = new Dialogue("Uhhhh???\n Who's that, WHERE IS SHE?????????",img_Father_Angry);
        Dialogue d_TalkToUnknownWithOutChild4 = new Dialogue("Hahahaha :D \n I feel pitty for you \n GO check her out in the basement floor",img_UnknownCharacter);

        Dialogue d_SeesUknownCharacter1 = new Dialogue("Hello Smith\nHow are your kids? HAHAHAAA", img_UnknownCharacter);
        Dialogue d_SeesUknownCharacter2 = new Dialogue("Who are you ???!\nAnd why do you look so similar?!!!", img_Father);
        Dialogue d_SeesUknownCharacter3 = new Dialogue("Similar!! \nHAHAHAHAAAAA", img_UnknownCharacter);
        Dialogue d_SeesUknownCharacter4 = new Dialogue("No Smith not similar\nI'M YOU", img_UnknownCharacter);
        Dialogue d_SeesUknownCharacter5 = new Dialogue("I don't understand\nWhat do you want from us?", img_Father_Angry);
        Dialogue d_SeesUknownCharacter6 = new Dialogue("Two years ago you were involved in a car accident, an accident were I have lost my wife and kids! I have lost everything! And you were not convicted", img_UnknownCharacter);
        Dialogue d_SeesUknownCharacter7 = new Dialogue("You are the reason I have lived in hell for years", img_UnknownCharacter);
        Dialogue d_SeesUknownCharacter8 = new Dialogue("BUT THIS WAS AN ACCIDENT!!! ", img_Father);
        Dialogue d_SeesUknownCharacter9 = new Dialogue("Yes Smith yes, it was an accident and what I did today was also an accident", img_UnknownCharacter);
        Dialogue d_SeesUknownCharacter10 = new Dialogue("What have you done to them?! ", img_Father);
        Dialogue d_SeesUknownCharacter11 = new Dialogue("I unleashed a hallucination gas in the whole house so you are all drugged and hallucinated right now\nI'm sorry Smith, But you had to pay off", img_UnknownCharacter);

        l_WonderingD.Add(d_Wondering1);
        l_WonderingD.Add(d_Wondering2);
        l_WonderingD.Add(d_Wondering3);
        l_SarahVoiceD.Add(d_SarahVoice1);
        l_SarahVoiceD.Add(d_SarahVoice2);
        
        l_SeeBedD.Add(d_SeeBed);
        l_SeePosterD.Add(d_SeePoster);
        l_SeeSarahD.Add(d_SeeSarah1);
        l_SeeSarahD.Add(d_SeeSarah2);
        l_SeeSarahD.Add(d_SeeSarah3);
        l_SeeSarahD.Add(d_SeeSarah4);
        l_SeeSarahD.Add(d_SeeSarah5);
        l_SeeSarahD.Add(d_SeeSarah6);
        l_SeeSarahD.Add(d_SeeSarah7);
        l_LeaveRoomWithSarah.Add(d_LeaveRoomWithSarah1);
        l_LeaveRoomWithSarah.Add(d_LeaveRoomWithSarah2);
        l_LeaveRoomWithOutSarah.Add(d_LeaveRoomWithOutSarah1);
        l_LeaveRoomWithOutSarah.Add(d_LeaveRoomWithOutSarah2);

        l_TalkToUnknownWithChild.Add(d_TalkToUnknownWithChild1);
        l_TalkToUnknownWithChild.Add(d_TalkToUnknownWithChild2);
        l_TalkToUnknownWithChild.Add(d_TalkToUnknownWithChild3);
        l_TalkToUnknownWithChild.Add(d_TalkToUnknownWithChild4);
        l_TalkToUnknownWithChild.Add(d_TalkToUnknownWithChild5);
        l_TalkToUnknownWithOutChild.Add(d_TalkToUnknownWithOutChild1);
        l_TalkToUnknownWithOutChild.Add(d_TalkToUnknownWithOutChild2);
        l_TalkToUnknownWithOutChild.Add(d_TalkToUnknownWithOutChild3);
        l_TalkToUnknownWithOutChild.Add(d_TalkToUnknownWithOutChild4);

        l_SeesUknownCharacter.Add(d_SeesUknownCharacter1);
        l_SeesUknownCharacter.Add(d_SeesUknownCharacter2);
        l_SeesUknownCharacter.Add(d_SeesUknownCharacter3);
        l_SeesUknownCharacter.Add(d_SeesUknownCharacter4);
        l_SeesUknownCharacter.Add(d_SeesUknownCharacter5);
        l_SeesUknownCharacter.Add(d_SeesUknownCharacter6);
        l_SeesUknownCharacter.Add(d_SeesUknownCharacter7);
        l_SeesUknownCharacter.Add(d_SeesUknownCharacter8);
        l_SeesUknownCharacter.Add(d_SeesUknownCharacter9);
        l_SeesUknownCharacter.Add(d_SeesUknownCharacter10);
        l_SeesUknownCharacter.Add(d_SeesUknownCharacter11);

        // dialogues for noah
        l_enteringNoahRoomD = new List<Dialogue>();
        l_seeOrigamiD = new List<Dialogue>();
        l_blamingD = new List<Dialogue>();
        l_chooseNoahOnlyD = new List<Dialogue>();
        l_chooseSarahOnlyD = new List<Dialogue>();
        l_PlayRPSD = new List<Dialogue>();
        l_ChooseRockD = new List<Dialogue>();
        l_ChoosePaperD = new List<Dialogue>();
        l_ChooseScissorD = new List<Dialogue>();
        l_LeaveNoahRoomD = new List<Dialogue>();

        Dialogue d_enteringNoahRoom1 = new Dialogue("Noah!\nThank God you're Ok buddy!", img_Father);
        Dialogue d_enteringNoahRoom2 = new Dialogue("Son why are you not answering?\nWhat happened", img_Father);  // 1st action

        Dialogue d_seeOrigami3 = new Dialogue("What happened here?!Why are these Origamis flying all over the place\n", img_Father); //2nd

        Dialogue d_blaming1 = new Dialogue("The Man!He told me that you don't love me anymore, and soon you won't exist in my life anymore", img_Son);
        Dialogue d_blaming1_1 = new Dialogue("The Man!He told me that you don't love me anymore, and soon you won't exist in my life anymore", img_Son);
        Dialogue d_blaming2 = new Dialogue("What Man??!!!\nThat is not true don't believe him.", img_Father);
        Dialogue d_blaming3 = new Dialogue("I believe him. He had the needle of the truth, and he was right,\nYOU WENT TO SAVE SARAH FIRST!", img_Son);
        Dialogue d_blaming4 = new Dialogue("NOO! I just heard her first, now stop this and come with me to find your mom", img_Father); //2nd
        Dialogue d_blaming5 = new Dialogue("I'm not going with you dad, unless you beat me at the game", img_Son);
        Dialogue d_blaming6 = new Dialogue("Play Rock, Paper, Scissors with me dad!\nOr leave me here", img_Son);

        Dialogue d_chooseNoah1 = new Dialogue("You proved me wrong, you do care about me!", img_Son);
        Dialogue d_chooseNoah2 = new Dialogue("Let's get out of here son!", img_Father);

        Dialogue d_chooseSarah1 = new Dialogue("I knew it! you would choose her over me!", img_Son);
        Dialogue d_chooseSarah2 = new Dialogue("See you in another life dad", img_Son);

        Dialogue d_PlayRPS1 = new Dialogue("So now you play over us two, either take us both, or leave us forever as you always did.", img_Son);

        Dialogue d_chooseRock1 = new Dialogue("I beat you dad! I hate you!\nNow GET OUT OF MY ROOM!!!", img_Son);

        Dialogue d_choosePaper1 = new Dialogue("You knew I would choose paper....,You proved me wrong.....\nYou proved the man wrong!", img_Son_Good);
        Dialogue d_choosePaper2 = new Dialogue("Noah you are back!!", img_Father);
        Dialogue d_chooseScissor1 = new Dialogue("You knew I would choose paper....,You proved me wrong.....\nYou proved the man wrong!", img_Son_Good);
        Dialogue d_chooseScissor2 = new Dialogue("Noah you are back!!", img_Father);

        Dialogue d_leaveNoahRoom1 = new Dialogue("Let's search for Helen!", img_Father_Angry);


        l_enteringNoahRoomD.Add(d_enteringNoahRoom1);
        l_enteringNoahRoomD.Add(d_enteringNoahRoom2);

        l_seeOrigamiD.Add(d_seeOrigami3);

        l_blamingD.Add(d_blaming1);
        l_blamingD.Add(d_blaming1_1);
        l_blamingD.Add(d_blaming2);
        l_blamingD.Add(d_blaming3);
        l_blamingD.Add(d_blaming4);
        l_blamingD.Add(d_blaming5);
        l_blamingD.Add(d_blaming6);

        l_chooseNoahOnlyD.Add(d_chooseNoah1);
        l_chooseNoahOnlyD.Add(d_chooseNoah2);

        l_chooseSarahOnlyD.Add(d_chooseSarah1);
        l_chooseSarahOnlyD.Add(d_chooseSarah2);

        l_PlayRPSD.Add(d_PlayRPS1);

        l_ChooseRockD.Add(d_chooseRock1);

        l_ChoosePaperD.Add(d_choosePaper1);
        l_ChoosePaperD.Add(d_choosePaper2);

        l_ChooseScissorD.Add(d_chooseScissor1);
        l_ChooseScissorD.Add(d_chooseScissor2);

        l_LeaveNoahRoomD.Add(d_leaveNoahRoom1);





    }

    private void Start()
    {
        l_Act_Entrance = new List<Action>();
        l_Act_Sarah = new List<Action>();
        l_Act_Noah = new List<Action>();
        l_Act_Elevator = new List<Action>();
        l_Act_Finale = new List<Action>();

        InitializeDialogues();
        InitializeActions();
        
        StateInstance = new State();
        StateInstance.e_CurrentAct = Act.ENTRANCE;
        StateInstance.l_Actions = l_Act_Entrance;
      
    }

}
