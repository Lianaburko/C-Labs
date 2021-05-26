# include <iostream>
using namespace std;
struct Stack
{
	int info;
	Stack* next;
};
Stack* inStack(Stack* begin)
{
	Stack* elements = new Stack;
	cout << "Enter information which you want : ";
	cin >> elements->info;
	elements->next = begin;
	return elements;
}
void addNewElement(Stack* begin)
{
	Stack* newElements = new Stack;
	cout << "Enter new elements : ";
	cin >> newElements->info;
	newElements->next = begin->next;
	begin->next = newElements;
}

void view(Stack* begin)
{
	while (begin)
	{
		cout << begin->info << endl;
		begin = begin->next;
	}
}
void individualTask(Stack* begin)
{
	/*в этой функции по сути и надо поместить это задание под номером 12.*/

}
void sort(Stack* begin)
{
	Stack* currentElement = NULL, *nextElement;
	do
	{
		for (nextElement = begin; nextElement->next != currentElement; nextElement = nextElement->next)
		{
			if (nextElement->info > nextElement->next->info)
			{
				int temp = nextElement->info;
				nextElement->info = nextElement->next->info;
				nextElement->next->info = temp;
			}
		}
		currentElement = nextElement;
	} while (begin->next != currentElement);
}
void delElement(Stack* begin)
{
	Stack* Element = begin->next;
	begin->next = begin->next->next; //begin->next=Element->next;
	delete Element;
}
void delAll(Stack** begin)
{
	Stack* elements;
	while (*begin != NULL)
	{
		elements = *begin;
		*begin = (*begin)->next;
		delete elements;
	}
}
int main()
{
	Stack* begin = NULL;
	int choice = 0, a = 0;
	cout << "MENU\n1. Create\n2. Add\n3. View\n4. Individual task\n5. Sort\n6. Delete element\n7. Delete all\nEnter any symbol or letter if you want to exit" << endl;
	cin >> choice;
	do
	{
		switch (choice)
		{
			case 1:
				begin = inStack(begin);
				break;
			case 2:
				addNewElements(begin);
				break;
			case 3:
				view(begin);
				break;
			case 4:
				individualTask(begin);
				break;
			case 5:
				sort(begin);
				break;
			case 6:
				delNewElements(begin);
				break;
			case 7:
				delAll(&begin);
				break;
			default:
				a = 1;
		}
	} while (a == 0);
	system("pause");
	return 0;
}