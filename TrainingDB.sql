create table Course ( 
    CourseID        int identity(1,1) not null, 
    CourseName       varchar(40) not null, 
    primary key (CourseID) )

create table Faculty ( 
    FacultyID        int identity(1,1) not null, 
    Name       varchar(20) not null,     
    Pratice        varchar(30) not null, 
    primary key (FacultyID) )

create table Trainee ( 
    TraineeID       int identity(1,1) not null, 
    Name       varchar(20) not null,     
    primary key (TraineeID) )


create table Training ( 
    TrainingID        int identity(1,1) not null, 
    CourseID        int not null, 
    FacultyID     int not null, 
	DurationInWeeks int not null,
	Fee				money not null,
    primary key (TrainingID), 
    foreign key (CourseID) references Course (CourseID), 
    foreign key (FacultyID) references Faculty (FacultyID) )

create table Enrollment ( 
    EnrollID        int identity(1,1) not null, 
    TrainingID        int not null, 
    TraineeID        int not null,
    primary key (EnrollID), 
    foreign key (TrainingID) references Training (TrainingID), 
    foreign key (TraineeID) references Trainee (TraineeID))