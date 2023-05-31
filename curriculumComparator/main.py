import nltk
import pymorphy2

from texts import hse_full, imcsn_full, hsmi_full

sw = nltk.corpus.stopwords.words('russian')
tokenizer = nltk.tokenize.RegexpTokenizer(r'\w+')
morph = pymorphy2.MorphAnalyzer()

texts = nltk.text.TextCollection([hse_full, imcsn_full, hsmi_full])


def to_normal_form(text):
    text_tokens = tokenizer.tokenize(text.lower())

    remove_sw = [word for word in text_tokens if word not in sw]

    lemmatize = [morph.parse(word)[0].normal_form for word in remove_sw]

    return lemmatize


def calculate(all_words, words):
    no_dup = list(dict.fromkeys(words))
    res = [[all_words.tf_idf(word, words), word] for word in no_dup]
    return [word for word in res if word[0] > 0.01]


def compare(first_collection, second_collection):
    count = 0
    for q in first_collection:
        for w in second_collection:
            if q[1] == w[1]: count += 1

    return count * 2 / (len(first_collection) + len(second_collection)) * 100


a = to_normal_form(hse_full)
b = to_normal_form(imcsn_full)
c = to_normal_form(hsmi_full)

ac = calculate(texts, a)
bc = calculate(texts, b)
cc = calculate(texts, c)

print("hse imcsn " + str(compare(ac, bc)) + "%")
print("imcsn hsmi " + str(compare(cc, bc)) + "%")
print("hse hsmi " + str(compare(cc, ac)) + "%")
