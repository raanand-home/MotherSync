__author__ = 'home'
import sys
import xml.etree.ElementTree as ET
import re

class getXmlFile:

    def __init__(self,fileName):
        self.fileName = fileName
        self.xmldoc = ET.parse(fileName)
        self.src_dir = self.xmldoc.findall("src_dir")
#        self.src_dir = dir.text
        dir = self.xmldoc.find("inc_dir")
        self.inc_dir = dir.text
        dir = self.xmldoc.find("exec_dir")
        self.exe_dir = dir.text
        dir = self.xmldoc.find("dep_dir")
        self.dep_dir = dir.text
        dir = self.xmldoc.find("make_inc_file")
        self.make_inc_file = dir.text
        print "src_dir=",self.src_dir,"inc_dir=",self.inc_dir,"exe_dir=",self.exe_dir,"make_file",self.make_inc_file

    def convertToMakeFile(self):
        i = 0
        dir_str = "x"
        file = open(self.make_inc_file,"w")
        for dir in self.src_dir:
            i = i + 1
            file.write("SRC_DIR_" +  i.__str__() + " = " + dir.text + "\n")

            file.write("CPP_FILES_DIR_" +  i.__str__() + " := $(wildcard $(SRC_DIR_" +  i.__str__() +  ")/*.cpp)\n")

            index = dir.text.find("/")
            if (index == -1):
                file.write("DEP_DIR_" + i.__str__() + " = " + self.dep_dir + "\n")
            else:
                file.write("DEP_DIR_" + i.__str__() + " = " + self.dep_dir + dir.text[index:] + "\n")

            file.write("DEP_FILES_" + i.__str__() + ":= $(join $(subst $(SRC_DIR_" + i.__str__() +
                ")," + "$(DEP_DIR_" + i.__str__() + "),$(dir $(CPP_FILES_DIR_" +  i.__str__() +
                "))), $(patsubst %.cpp, %.d ,$(notdir $(CPP_FILES_DIR_" + i.__str__() + "))))\n" )

#            file.write("DEP_FILES_" + i.__str__() + ":= $(join $(subst $(SRC_DIR_" + i.__str__() +
#                ") ,$(DEP_DIR_" + i.__str__() + ")/,$(dir $(CPP_FILES_DIR_" +  i.__str__() +
#                "))), $(patsubst %.cpp, %.d ,$(notdir $(CPP_FILES_DIR_" + i.__str__() + "))))\n" )


#            file.write("DEP_FILES_", +  i.__str__() +
#                        ":= $(join $(subst $(SRC_DIR_", +   i.__str__() +")",$(DEP_DIR)/,$(dir $(CPP_FILES_DIR1))), $(patsubst %.cpp, %.d ,$(notdir $(CPP_FILES_DIR1))))


        i = 0
        for dir in self.src_dir:
            i = i + 1

            if ( i == 1):
                file.write("CPP_FILES := $(CPP_FILES_DIR_" +  i.__str__() +  ") ")
            else:
	            file.write("\\ \n \t  $(CPP_FILES_DIR_" +  i.__str__() +  "  )")

        file.write("\nINC_DIR = " + self.inc_dir)
        file.write("\nEXEC_DIR = " + self.exe_dir)
        file.write("\nDEP_DIR = " + self.dep_dir)
        file.close()





mk = getXmlFile("InputFiles.xml")   #(sys.argv[1])
mk.convertToMakeFile()