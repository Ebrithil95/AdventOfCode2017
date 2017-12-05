#include <fstream>
#include <iostream>
#include <vector>

int main(int argc, char** argv) {
	std::ifstream infile("input.txt");
	std::vector<int> vals;
	vals.reserve(1057);

	int num;
	while (infile >> num) {
		vals.push_back(num);
	}

	auto vals1 = std::vector<int>(vals);
	int index = 0;
	int jumps = 0;
	while (index >= 0 && index < vals1.size()) {
		num = vals1[index];
		vals1[index] = num + 1;
		index += num;
		jumps++;
	}

	std::cout << jumps << std::endl;

	index = 0;
	jumps = 0;
	while (index >= 0 && index < vals.size()) {
		num = vals[index];
		vals[index] = num >= 3 ? num - 1 : num + 1;
		index += num;
		jumps++;
	}

	std::cout << jumps << std::endl;
	return 0;
}

