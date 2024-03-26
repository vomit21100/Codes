from selenium import webdriver
from selenium.webdriver.edge.options import Options
from selenium.webdriver.edge.service import Service
from selenium.webdriver.common.by import By   

def Get_cookie(user_email, user_password):
    #Set options
    options = Options()
    options.add_argument("--disable-notifications")
    s = Service('./edgedriver_win64/msedgedriver')

    #Open Login website
    edge = webdriver.Edge(service = s, options=options)
    edge.get("https://royaleapi.com/login/twitter")

    #locate component position
    email = edge.find_element(By.ID, "username_or_email")
    password = edge.find_element(By.ID, "password")
    button = edge.find_element(By.ID, 'allow')

    #Try login website
    email.send_keys('deavatar6503@gmail.com')
    password.send_keys('gran21100')
    button.click()

    #Get necessary cookie
    cookie_raw = edge.get_cookie('__royaleapi_session_v2')
    edge.quit()

    #handeling cookie to demand format
    cookie = '{cookie_name}={cookie_value}'.format(
        cookie_name = cookie_raw['name'],
        cookie_value = cookie_raw['value']
    )

    return cookie