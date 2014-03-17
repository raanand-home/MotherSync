# Makefile for Writing Make Files Example

# *****************************************************
# Variables to control Makefile operation

CXX = g++
CXXFLAGS = -Wall -g
SUFFIXES += .d

#SOURCES := $(shell find src/ -name "*.cpp")


SRC_DIR1 = src
SRC_DIR2 = src/src1

# Make does not offer a recursive wildcard function, so here's one:
rwildcard=$(wildcard $1$2) $(foreach d,$(wildcard $1*),$(call rwildcard,$d/,$2))
sdf = $(call python.exe )

CPP_FILES := $(call rwildcard,src/,*.cpp)


CPP_FILES_DIR1 := $(wildcard $(SRC_DIR1)/*.cpp)
CPP_FILES_DIR2 := $(wildcard $(SRC_DIR2)/*.cpp)

DEP_FILES1 := $(join $(subst $(SRC_DIR1),dep,$(dir $(CPP_FILES_DIR1))), $(patsubst %.cpp, %.d ,$(notdir $(CPP_FILES_DIR1))))

DEP_FILES2 := $(join $(subst $(SRC_DIR2),dep/src1,$(dir $(CPP_FILES_DIR2))), $(patsubst %.cpp, %.d ,$(notdir $(CPP_FILES_DIR2))))


DEP_FILES := $(join $(subst src/,dep/,$(dir $(CPP_FILES))), $(patsubst %.cpp, %.d ,$(notdir $(CPP_FILES))))

OBJ_FILES := $(join $(subst src/,obj/,$(dir $(CPP_FILES))), $(patsubst %.cpp, %.d ,$(notdir $(CPP_FILES))))

INC_FILE = inc
INC_DIR = inc
OBJ_DIR = obj
EXEC_DIR = exe
DEP_DIR = dep
DEP_DIR1 = dep/src1

GET_DEP_FILES = $(CXX) -I $(INC_DIR) -MM -MT $(patsubst $(SRC_DIR1)%.cpp,$(OBJ_DIR)%.o,$<) $< -MF $@

SET_INC_FILE = echo '\t' $(CXX) $(CXXFLAGS)  -I $(INC_DIR) -c -o \
 $(join $(subst $(DEP_DIR),$(OBJ_DIR),$(dir $@)), $(patsubst %.d, %.o ,$(notdir $@))) \
 $<  >>		$@

#VAR := $(shell python makeInputFile.py) # InputFiles.xml

#-include input_test.mk

get_dir := $(shell $(scripts))
#DEPS_FILES = $(CPP_FILES):%.cpp=%.d)
#-include input_test.mk
#-include dep/file1.d

#VPATH = src

#OBJS = $(subst .cpp, .d, $(VPATH))

# ****************************************************
# Targets needed to bring the executable up to date 

.PHONY:
$(EXEC_DIR)/main: $(DEP_FILES) $(OBJ_FILES) #	$(DEP_FILES1) $(DEP_FILES2) $(OBJ_FILES) 
	@echo "build exe"
	$(scripts)
	$(CXX) $(CXXFLAGS)  -o $@ $(OBJ_FILES) $(OBJ_FILES_1)


$(DEP_DIR)/%.d: $(SRC_DIR1)/%.cpp

	
	@echo create ---- $@
	@echo src-dir ----------------- $(SRC_DIR)
	$(CXX) -I $(INC_DIR) -MM -MT $(patsubst $(SRC_DIR1)%.cpp,$(OBJ_DIR)%.o,$<) $< -MF $@
#	$(GET_DEP_FILES)
#	$(SET_INC_FILE)
	echo '\t' $(CXX) $(CXXFLAGS)  -I $(INC_DIR) -c -o \
 $(join $(subst $(DEP_DIR),$(OBJ_DIR),$(dir $@)), $(patsubst %.d, %.o ,$(notdir $@))) \
 $<  >>		$@

$(DEP_DIR1)/%.d: $(SRC_DIR2)%.cpp

	@echo create ---- $@
	@echo src-dir ----------------- $(SRC_DIR2)
	$(CXX) -I $(INC_DIR) -MM -MT $(patsubst $(SRC_DIR2)%.cpp,$(OBJ_DIR)%.o,$<) $< -MF $@
	echo '\t' $(CXX) $(CXXFLAGS)  -I $(INC_DIR) -c -o \
 $(join $(subst $(DEP_DIR1),$(OBJ_DIR),$(dir $@)), $(patsubst %.d, %.o ,$(notdir $@))) \
 $<  >>		$@


#-include "dep/file1.d"
-include $(DEP_FILES)
#-include $(DEP_FILES1)
#	@echo xxxx
#	$(CXX) $(CXXFLAGS)  -I $(INC_DIR) -c -o $@ $<
#-include $(DEP_FILES2)

.PHONY:
run_scripts:
	@echo "----------------------------------------------"
	@echo cpp $(CPP_FILES)
	$(scripts)

create_dir:
	mkdir $(OBJ_DIR) > /dev/null ;true
	-mkdir $(EXEC_DIR) > /dev/null
	@echo "create dir"
clean:
	-rm  $(OBJ_DIR)/*.o
	-rm  $(EXEC_DIR)/*
	-rm  $(DEP_DIR)/*.d
	-rm  $(DEP_DIR)/src1/*.d



debug:
	@echo CPP_FILES_DIR_1 = $(CPP_FILES_DIR1)
	@echo CPP_FILES_DIR2 = $(CPP_FILES_DIR2)
	@echo DEP_FILES1 - $(DEP_FILES1)
	@echo DEP_FILES2 - $(DEP_FILES2)
	@echo DEP_FILES - $(DEP_FILES)
	@echo SRC_DIR_1 - $(SRC_DIR_1)
	@echo DEP_DIR_1 - $(DEP_DIR_1)
	@echo CPP_FILES_DIR_1 - $(_FILES_DIR_1)
	@echo DEP_FILES_1 - $(DEP_FILES_1)
	@echo OBJ_FILES - $(OBJ_FILES)
	@echo CPP_FILES - $(CPP_FILES)
	@echo TEST_1 - $(TEST_1)
	@echo TEST_2 - $(TEST_2)
	@echo TEST_3 - $(TEST_3)
	@echo TEST_4 - $(ALL_CPP)

