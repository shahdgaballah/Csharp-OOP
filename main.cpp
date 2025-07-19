#include <iostream>

using namespace std;

const int MAX_USERS = 1000;
const int MAX_QUESTIONS = 1000;
const int MAX_ANSWERS= 1000;

struct User{
    int id;
    string username, password, email, name;
};
struct Question{
    int id;
    int from_user_id;
    int to_user_id;
    string text;
    string answer;



};
struct Answer{
    int question_id;
    string text;
};

struct Askfm_system{
    User users[MAX_USERS];
    Question questions[MAX_QUESTIONS];
    Answer answers[MAX_ANSWERS];

    int users_count=0;
    int questions_count=0;
    int answers_count=0;

    int current_user_id = -1;

void Main_menu(){
    while (true){
      cout<< "Menu:\n 1.Login\n 2.Sign up\n";
      cout<<"Enter a number in range 1-2: ";

      int number; cin>>number;
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
 }

void Signup(){
    if(users_count>=MAX_USERS){
        cout<<"Can't add more users\n";
        return;
    }
    User user1;
    user1.id = users_count + 1;
    cout<< "Enter username (No spaces): "; cin>>user1.username;
    cout<<"Enter password: "; cin>>user1.password;
    cout<<"Enter name: "; cin>>user1.name;
    cout<<"Enter email: "; cin>>user1.email;

    users[users_count] = user1;
    users_count++;
    //cout<<"Allow anonymous questions?(0 or 1): ";
    //int number; cin>>number;
    //implement fun to handle this ques

     App_menu();
  }

void Login(){
    string username, password;
    cout<< "Enter username & password: ";
    cin>>username; cin>>password;

    for(int i =0; i<users_count; i++){
        if(username == users[i].username && password == users[i].password){
            App_menu();
        }

       else{
        cout<<"User is not registered. Sign up!";
           Main_menu();
         }

    }
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
cout<<"8. Log out\n";
cout<<"Enter a number in range 1 -8: ";

int number; cin>>number;
if(number <1 || number > 8){
    cout<< "Error: invalid number. Try again!\n";
    App_menu();

}
if (number == 1) Print_ques_to_me();
else if (number == 2) Print_ques_from_me();
else if (number == 3) Answer_question();
else if (number == 4) Delete_question();
else if (number == 5) Ask_question(current_user_id);
else if (number == 6) List_system_users();
else if (number == 7) Show_feed();
else if (number == 8) Logout();
}
void Print_ques_to_me(){
    bool flag = false;
    for (int i = 0; i < questions_count; i++) {
        if (questions[i].to_user_id == current_user_id) {
            flag = true;
            cout << "Question ID: " << questions[i].id << " from User ID: " << questions[i].from_user_id << "\n";
            cout << "Question: " << questions[i].text << "\n";
        }
    }
    if (!flag) {
        cout << "No questions recieved\n";
        App_menu();
    }
}

void Print_ques_from_me(){
    bool flag = false;
    for (int i = 0; i < questions_count; i++) {
        if (questions[i].from_user_id == current_user_id) {
            flag = true;
            cout << "Question ID: " << questions[i].id << " to User ID: " << questions[i].to_user_id << "\n";
            cout << "Question: " << questions[i].text << "\n";
        }
    }
    if (!flag) {
        cout << "No questions sent\n";
    }
}

void Ask_question(int from_user_id){
    cout<< "Enter user id or -1 to cancel: ";

    int to_user_id; cin>>to_user_id;
    if(to_user_id == -1) return;

    cout<< "Note: Anonymous questions are not allowed for this user";
    cout<< "For thread question: enter question id or -1 for new question: ";

    int q_id; cin>>q_id;
    if(q_id == -1){

    cout<< "Enter question text";
    string text; cin>>text;
    Question question1;

    question1.id = questions_count + 1;
    question1.from_user_id = from_user_id;
    question1.to_user_id = to_user_id;
    question1.text = text;
    question1.answer = "";
    questions[questions_count] = question1;
    questions_count++;
}

}

void Answer_question(){

cout<<"Enter question id or -1 to cancel: ";

int q_id; cin>>q_id;

if(q_id == -1) return;

bool flag = false;
for (int i =0; i<questions_count; i++){

        if(questions[i].id==q_id){
            flag=true;
            cout<<"Question: "<<questions[i].text<<"\n";
            break;

        }
    }
if(!flag){
            cout<<"Question not found";
            return;
}
cout<<"Enter your answer: ";

string answer_text; cin>>answer_text;

Answer answer1;
answer1.question_id = q_id;
answer1.text = answer_text;

answers[answers_count] = answer1;
answers_count++;


}

void Delete_question(){

cout<<"Enter question id or -1 to cancel: ";

int q_id; cin>>q_id;

if(q_id == -1) return;

bool flag = false;
for (int i =0; i<questions_count; i++){

        if(questions[i].id==q_id){

            for(int j =i+1; j<questions_count; j++){
                questions[j-1] = questions[j];
            }
            questions_count--;
            flag=true;
            break;


        }
}
if(!flag){
    cout<<"Question not found\n";
    return;
}

}

void List_system_users(){

for(int i =0; i<users_count; i++){

    if(users[i].name == " "){

    continue;
   }
   else{
      cout<<"Id: "<<users[i].id<< " "<<"Name: "<<users[i].name<<"\n";


   }
}

}

void Show_feed(){

}

void Logout(){

cout<< "Logged out! ";

Main_menu();

}


};


int main()
{

Askfm_system askfm;
askfm.Main_menu();

return 0;

}
