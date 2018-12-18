import json
import os
import pickle
from joblib import dump, load
from pprint import pprint
from sklearn.linear_model import LogisticRegression
from sklearn.svm import SVC


with open(r".\datasets\train_set_0_boy.txt", 'r') as data_file:    
    train_set_0 = json.load(data_file)
with open(r".\datasets\train_set_1_boy.txt", 'r') as data_file:    
    train_set_1 = json.load(data_file)
with open(r".\datasets\train_set_2_boy.txt", 'r') as data_file:    
    train_set_2 = json.load(data_file)
with open(r".\datasets\train_set_3_boy.txt", 'r') as data_file:    
    train_set_3 = json.load(data_file)
with open(r".\datasets\train_set_4_boy.txt", 'r') as data_file:    
    train_set_4 = json.load(data_file)

with open(r".\datasets\test_set_0_boy.txt", 'r') as data_file:    
    test_set_0 = json.load(data_file)
with open(r".\datasets\test_set_1_boy.txt", 'r') as data_file:    
    test_set_1 = json.load(data_file)
with open(r".\datasets\test_set_2_boy.txt", 'r') as data_file:    
    test_set_2 = json.load(data_file)
with open(r".\datasets\test_set_3_boy.txt", 'r') as data_file:    
    test_set_3 = json.load(data_file)
with open(r".\datasets\test_set_4_boy.txt", 'r') as data_file:    
    test_set_4 = json.load(data_file)

train_set_data = []
train_set_labels = []
test_set_data = []
test_set_labels = []
for item in train_set_0:
    train_set_data.append(item)
    train_set_labels.append(0)
for item in train_set_1:
    train_set_data.append(item)
    train_set_labels.append(1)
for item in train_set_2:
    train_set_data.append(item)
    train_set_labels.append(2)
for item in train_set_3:
    train_set_data.append(item)
    train_set_labels.append(3)
for item in train_set_4:
    train_set_data.append(item)
    train_set_labels.append(4)      

for item in test_set_0:
    test_set_data.append(item)
    test_set_labels.append(0)
for item in test_set_1:
    test_set_data.append(item)
    test_set_labels.append(1)
for item in test_set_2:
    test_set_data.append(item)
    test_set_labels.append(2)
for item in test_set_3:
    test_set_data.append(item)
    test_set_labels.append(3)
for item in test_set_4:
    test_set_data.append(item)
    test_set_labels.append(4)         

logisticRegr = SVC(kernel='linear', probability=True)
logisticRegr.fit(train_set_data, train_set_labels)
print(logisticRegr.predict_proba([test_set_2[1]]))
score = logisticRegr.score(test_set_data,test_set_labels)

print(score)
dump(logisticRegr, 'model.joblib') 