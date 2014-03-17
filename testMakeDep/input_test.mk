SRC_DIR_1 = src
CPP_FILES_DIR_1 := $(wildcard $(SRC_DIR_1)/*.cpp)
DEP_DIR_1 = dep
DEP_FILES_1:= $(join $(subst $(SRC_DIR_1),$(DEP_DIR_1),$(dir $(CPP_FILES_DIR_1))), $(patsubst %.cpp, %.d ,$(notdir $(CPP_FILES_DIR_1))))
SRC_DIR_2 = src/src1
CPP_FILES_DIR_2 := $(wildcard $(SRC_DIR_2)/*.cpp)
DEP_DIR_2 = dep/src1
DEP_FILES_2:= $(join $(subst $(SRC_DIR_2),$(DEP_DIR_2),$(dir $(CPP_FILES_DIR_2))), $(patsubst %.cpp, %.d ,$(notdir $(CPP_FILES_DIR_2))))
CPP_FILES := $(CPP_FILES_DIR_1) \ 
 	  $(CPP_FILES_DIR_2  )
INC_DIR = inc
EXEC_DIR = exe
DEP_DIR = dep