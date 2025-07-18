#include <iostream>

using namespace std;

struct User{
    const int MAX_USERS = 1000;
    int user_ids[MAX_USERS];
    string usernames[MAX_USERS];
    string passwords[MAX_USERS];
    string email[MAX_USERS];
    string names[MAX_USERS];

    int users_count=0;

};
struct Helper{

void Main_menu(){
    cout<< "Menu:\n 1.Login\n 2.Sign up\n";
    cout<<"Enter a number in range 1-2: ";
    int number;
    cin>>number;
    if(number == 1){
        Login();
    }
    else if(number == 2){
        Signup();
    }
    else{
        cout<< "Enter a number in range 1-2!\n";
        Main_menu();
    }
}
};

struct Question{
    const int MAX_QUESTIONS = 1000;
    const int MAX_TEXT = 100;

    string questions[MAX_QUESTIONS];
    int question_ids[MAX_QUESTIONS];
    int questions_count=0;

    string question_text[MAX_TEXT];
    int question_text_count=0;



};
struct Answer{
     string answers[MAX_QUESTIONS];
     int answers_count=0;

     const int MAX_TEXT = 100;
     string answer_text[MAX_TEXT];
     int answer_text_count=0;




};



struct App_menu{
  void Print_ques_to_me(){

   cout<< "Question Id (question.id) from user (user.id)\nQuestion: (Question.content)\nAnswer: (Answer.content)"


}
void Print_ques_from_me(){

     cout<< "Question Id (question.id) from user (user.id)\nQuestion: (Question.content)\nAnswer: (Answer.content)"

}
void Ask_question(){
    cout<< "Enter user id or -1 to cancel: ";
    int user_id; cin>>user_id;
    if(id == -1) return; //for now
    else{
        User.user_ids[User.users_count] = user_id;
        User.users_count++;
    }
    cout<< "Note: Anonymous questions are not allowed for this user";
    cout<< "For thread question: enter question id or -1 for new question: ";
    int que_id; cin>>que_id;
    if(que_id == -1){
    cout<< "Enter question text";
    string text; cin>>text;
    Question.questions_text[Question.question_text_count]=text;
    Question.question_text_count++;

    }
    else{
    Question.question_ids[Question.questions_count]=question_id;
    Question.questions_count++;
    cout<< "Enter question text";
    string text; cin>>text;
    Question.question_text[Question.question_text_count]=text;
    Question.question_text_count++;
    }


}

void Answer_question(){
    cout<<"Enter question id or -1 to cancel: ";
    int question_id; cin>>question_id;
    if(question_id == -1) return; //for now
    else{
        for(int i=0; i<Question.question_ids.length(); i++){
            if(Question.question_ids[i]==question_id){
                cout<<Question.question_text<<"\n";
            }
        }
        string answer; cin>>answer;
        Answer.answer_text[Answer.answer_text_count] = answer;
        Answer.answer_text_count++;

    }


}
void Delete_question(){


}

void List_system_users(){


}
void Show_feed(){

}



void App_menu(){
    cout<<"Menu:\n ";

    cout<<"1. Print questions to me\n";

    cout<<"2. Print questions from me\n";

    cout<<"3. Answer question\n";

    cout<<"4. Delete question\n";

    cout<<"5. Ask question\n";

    cout<<"6. List system users\n";

    cout<<"7. Feed\n";

    cout<<"8. Log out";

    cout<<"Enter a number in range 1 -8: ";
    int number; cin>>number;

    if(number <1 || number > 8){
        cout<< "Error: invalid number. Try again!\n";
        App_menu();
    }

    if (choice == 1) Print_ques_to_me();
    else if (choice == 2) Print_ques_from_me();
    else if (choice == 3) Answer_question();
    else if (choice == 4) Delete_question();
    else if (choice == 5) Ask_question();
    else if (choice == 6) List_system_users();
    else if (choice == 7) Show_feed();
    else if (choice == 8) Logout();


   }

};

void Login(){
    cout<< "Enter username & password: ";
    App_menu();



}
void Logout(){
    cout<< "Logged out! ";
    Main_menu();

}


void Signup(){
    cout<< "Enter username (No spaces): ";
    string username; cin>>username;

    cout<<"Enter password: ";
    string password; cin>>password;

    cout<<"Enter name: ";
    string name; cin>>name;

    cout<<"Enter email: ";
    string email; cin>>email;

    cout<<"Allow anonymous questions?(0 or 1): "
    int number; cin>>number;
    //implement fun to handle this ques
    usernames[users_count]=username;
    passwords[users_count]=password;
    names[users_count]=name;
    email[users_count]=email;
    users_count++:

    App_menu();

}


int main()
{
    Helper helper;
    helper.Main_menu();
    return 0;
}
