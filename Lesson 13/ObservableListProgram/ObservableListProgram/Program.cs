
using ObservableListProgram;

var someList = new ObservableList<int>();
var newItem = 2;
var newItem2 = 3;

someList.Remove(newItem);
someList.Add(newItem);
someList.Add(newItem);
someList.Add(newItem2);
someList.Remove(newItem);


