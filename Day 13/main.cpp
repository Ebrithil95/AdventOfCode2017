#include <iostream>
#include <fstream>
#include <vector>

struct Layer {
	std::uint16_t depth;
	std::uint16_t range;
};

int calcPos(int step, int maxIndex)
{
	int backwards = (step / maxIndex) % 2;
	int mod = step % maxIndex;

	return backwards ? maxIndex - mod : mod;
}

int main()
{
	std::vector<Layer> layers;

	//Parse input
	{
		std::ifstream infile("input.txt");
		std::string line;
		int index;
		while (std::getline(infile, line))
		{
			Layer newLayer;
			index = line.find(':');
			newLayer.depth = std::stoi(line.substr(0, index));

			newLayer.range = std::stoi(line.substr(index + 2));

			layers.push_back(newLayer);
		}
		infile.close();
	}

	std::uint64_t offset = 0;
	bool first = true;
	std::uint64_t severity;
	do
	{
		severity = 0;
		for (int i = 0; i < layers.size(); ++i)
		{
			if (calcPos(layers.at(i).depth + offset, layers.at(i).range - 1) == 0)
			{
				severity += layers.at(i).range * (layers.at(i).depth + offset);
				if (!first) break;
			}
		}
		if (severity != 0) ++offset;
		if (first)
		{
			std::cout << severity << std::endl;
			first = false;
		}
	}while(severity != 0);
	std::cout << offset << std::endl;

	return 0;
}