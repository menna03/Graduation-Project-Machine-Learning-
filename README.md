# SnapFit – Machine Learning Models

Welcome to the Machine Learning repository for SnapFit — an AI-powered fashion styling mobile application developed as part of our Graduation Project at Cairo University.

SnapFit helps users coordinate outfits and explore new styles using deep learning, computer vision, and a personalized styling engine.

💡 Features
👕 Human Parsing
Used both:

👕 Pretrained Human Parsing Model (from GitHub)

We used a pretrained human parsing model to segment different clothing parts from full-body images.

<table> <tr> <td align="center"><b>Original Image</b></td> <td align="center"><b>Parsing Output</b></td> </tr> <tr> <td align="center"><img width="325" height="379" src="https://github.com/user-attachments/assets/421c9380-7db3-4148-a361-7f019f2572a7" alt="Original Image" /></td> <td align="center"><img width="321" height="373" src="https://github.com/user-attachments/assets/81e18fba-0dfc-4110-91e5-7036ff68ac21" alt="Parsing Output" /></td> </tr> </table>

🧠 Inference Code Example:
<img width="814" height="273" src="https://github.com/user-attachments/assets/ecfcc682-5013-480a-b15a-9f020cc53c89" alt="Inference Code" />


🧠 Custom U-Net Model for Human Parsing
We built a U-Net architecture from scratch to enhance segmentation performance and gain more control over training and evaluation.

📉 Training Progress
<table> <tr> <td align="center"><b>First Epoch</b></td> <td align="center"><b>Last Epoch</b></td> </tr> <tr> <td><img width="909" height="212" src="https://github.com/user-attachments/assets/f8576a23-32bb-467b-8dc2-f5a32eca7c0d" alt="First Epoch" /></td> <td><img width="889" height="211" src="https://github.com/user-attachments/assets/f94589a6-c479-4785-85a0-9d3e87f070d3" alt="Last Epoch" /></td> </tr> </table>
🧪 Test Example
Below is a test result showing the U-Net segmentation output on an unseen image:

<p align="center"> <img width="799" height="374" src="https://github.com/user-attachments/assets/e082ef31-fc4e-41f8-a467-849bfd2cc1c5" alt="U-Net Test Output" /> </p>
🏷️ Output with Category IDs
The segmented regions are labeled using category IDs, identifying different clothing parts:

<p align="center"> <img width="939" height="298" src="https://github.com/user-attachments/assets/63242860-52d2-401c-b46f-405749e7295a" alt="Category ID Output" /> </p>

📊 Multi-Label Classification
We developed several CNN-based classification models using ResNet-101 to identify and categorize clothing items across various dimensions.

1️⃣ Clothes Type Classification
Classes: Top, Bottom, Dress, Shoes, Bags

Architecture: ResNet-101

Accuracy: 98%

<table> <tr> <td><img width="352" height="433" src="https://github.com/user-attachments/assets/ab5cac3c-8ccc-40ce-8465-a3279b2cc3ae" alt="Clothes Type Input" /></td> <td><img width="343" height="418" src="https://github.com/user-attachments/assets/4e7e2e5b-50ad-4ac5-bea2-47694242f76c" alt="Clothes Type Result" /></td> </tr> </table>
2️⃣ Occasion Classification
Classes: Casual, Formal, Sports

Architecture: ResNet-101

Accuracy: 89%

<table> <tr> <td><img width="336" height="474" src="https://github.com/user-attachments/assets/92abb6fb-4288-4490-8c24-12f27fbe6989" alt="Occasion Input" /></td> <td><img width="322" height="475" src="https://github.com/user-attachments/assets/018fa9c1-8a78-4a41-8aa4-e9c1d60ccb22" alt="Occasion Result" /></td> </tr> </table>
3️⃣ Top Type Classification
Classes: Jackets, Shirts, Sweaters, Tops, T-shirts

Architecture: ResNet-101

Accuracy: 94%

<p align="center"> <img width="281" height="360" src="https://github.com/user-attachments/assets/78269b71-b59b-40a5-a3ff-5789467e8ec0" alt="Topwear Classification" /> </p>
4️⃣ Bottom Type Classification
Classes: Jeans, Shorts, Skirts, Track Pants, Trousers

Architecture: ResNet-101

Accuracy: 95%

<table> <tr> <td><img width="335" height="457" src="https://github.com/user-attachments/assets/55feca5b-e6f4-495a-adcc-fccc5b088450" alt="Bottom Type Input" /></td> <td><img width="356" height="459" src="https://github.com/user-attachments/assets/4da99616-3d0d-4571-a343-b688244f04a2" alt="Bottom Type Output" /></td> </tr> </table>
5️⃣ Shoe Type Classification
Classes: Casual/Formal Shoes, Sandals, Sports Shoes

Architecture: ResNet-101

Accuracy: 91%

<table> <tr> <td><img width="324" height="375" src="https://github.com/user-attachments/assets/a86927e6-ff7d-4959-8cb2-e3bb7b1f10b8" alt="Shoe Input" /></td> <td><img width="393" height="343" src="https://github.com/user-attachments/assets/63932bc3-9290-4325-9623-f369cafb681c" alt="Shoe Output" /></td> </tr> </table>



👗 AI Styling Engine
SnapFit includes a smart gender-based outfit generation engine designed to suggest compatible clothing combinations using AI.

👩 Women
Outfit Compatibility Results:

<img width="811" height="646" alt="SnapFit Women Outfit 1" src="https://github.com/user-attachments/assets/6727b44d-02e8-4b38-a249-137410037071" /> <br> <img width="974" height="419" alt="SnapFit Women Outfit 2" src="https://github.com/user-attachments/assets/8af442ee-dd47-4044-adf0-3be509e738b7" /> <br> <img width="915" height="375" alt="SnapFit Women Outfit 3" src="https://github.com/user-attachments/assets/57613646-63f0-4abf-a61e-eab56b31a4b5" />
👨 Men

✅ Example Input Items
Topwear:

<img width="755" height="332" alt="Men Topwear" src="https://github.com/user-attachments/assets/a5d7963c-8bca-4155-925f-0113c1536925" />

Shoes:

<img width="809" height="356" alt="Men Shoes" src="https://github.com/user-attachments/assets/e040f09e-830f-4c9f-9830-b23161d153c3" />

Bottomwear:

<img width="760" height="334" alt="Men Bottomwear" src="https://github.com/user-attachments/assets/7a83afc6-67c7-40c4-b92b-59a46cd5d56d" />
🧥 Winter Styling Logic for Men
If the input item is identified as winter wear (e.g., sweaters, boots), SnapFit automatically adds a compatible jacket to ensure warmth and aesthetic coordination.

✔ Ensures weather-appropriate layering

✔ Jacket compatibility in both style and season

Example 1:

<img width="964" height="304" alt="Winter Outfit 1" src="https://github.com/user-attachments/assets/1f52579c-5fc2-4cb7-a217-a9aca7662aff" />
Example 2:

<img width="984" height="321" alt="Winter Outfit 2" src="https://github.com/user-attachments/assets/d0d26f7e-9990-414f-9f16-4f38ef32479e" />

🔍 Similarity Matching
This module generates clothing embeddings and compares them to find visually similar items using vector similarity techniques .

Use Case:
Enables personalized fashion recommendations by identifying items that closely resemble each other in terms of style, texture, and color.

🔽 Example Output:
<img width="994" height="230" alt="image" src="https://github.com/user-attachments/assets/394f8d5a-14e3-44bb-bcc1-97ec58a35387" /> <img width="1009" height="229" alt="image" src="https://github.com/user-attachments/assets/9b0a7023-bbb8-4409-9bc2-7aaaa61f52f2" /> <img width="998" height="218" alt="image" src="https://github.com/user-attachments/assets/b7dafaff-7106-4a57-9886-4efff61891f9" />

3D Model 


MK Project Links

📦 Backend Repository: GitHub - Backend : https://lnkd.in/dCEYtkDV


🎨 Frontend Repository: GitHub - Frontend : https://lnkd.in/dGn3Xt7X 


🎬 Demo Video: Watch the Demo : https://lnkd.in/dSwUPgHs


