
using ObservableListProgram;

var notifier = new ObservableListNotifier<int>();
var someList = new ObservableList<int>();
someList.Add(2, notifier);