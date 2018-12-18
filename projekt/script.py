import json
import os
import pickle
from joblib import dump, load
from pprint import pprint
from sklearn.linear_model import LogisticRegression
import sys
import numpy 
from flask import Flask
from sklearn.svm import SVC

app = Flask(__name__)
with open(r".\data.txt", 'r') as data_file:    
    data = json.load(data_file)
model = load('model.joblib') 
@app.route('/')
def index():    
    with open(r".\data.txt", 'r') as data_file:    
        data = json.load(data_file)
    result = model.predict_proba([data])
    switcher = {
        0: "Piesc",
        1: "V",
        2: "Dlon",
        3: "OK",
        4: "Rogi",
    }
    print(result)
    index = numpy.argmax(result)
    result = numpy.max(result) 
    print(result)
    
    if  result < 0.7:
        result = "Nie rozpoznano"
    else: 
        result = switcher.get(index)

    return str(result)

if __name__ == '__main__':
    app.run(debug=True)