#include <GL/glut.h>
#include <armadillo>

void displayR(int points, arma::frowvec p1, arma::frowvec p2, arma::frowvec p3, arma::frowvec p4)
{
    arma::fmat R(points, 3);
    float inc = 0.5 / points;
    int index = 0;
    for (float r = 0; r <= 0.5 && index < points; r += inc)
        R.row(index++) = arma::frowvec({r * r, r, 1.0});
    arma::fmat N({{2, -4, 2}, {-3, 4, -1}, {1, 0, 0}});
    arma::fmat P = arma::join_cols(p1, p2, p3);
    arma::fmat B = R * N * P;

    glColor3f(1, 0, 0);
    glPointSize(3);
    glBegin(GL_POINTS);
    for (int i = 0; i < points; ++i)
    {
        // std::cout << B.row(i) << std::endl;
        glVertex2f(B(i, 0), B(i, 1));
    }
    glEnd();
    glFlush();
}

void displayC(int points, arma::frowvec p1, arma::frowvec p2, arma::frowvec p3, arma::frowvec p4)
{
    arma::fmat T(points, 4);
    float inc = 1.0 / points;
    int index = 0;
    for (float t = 0; t <= 1 && index < points; t += inc)
        T.row(index++) = arma::frowvec({t * t * t, t * t, t, 1.0});
    arma::fmat N({{-1, 3, -3, 1}, {2, -5, 4, -1}, {-1, 0, 1, 0}, {0, 2, 0, 0}});
    arma::fmat P = arma::join_cols(p1, p2, p3, p4);
    arma::fmat B = T / 2 * N * P;

    glColor3f(0, 1, 0);
    glPointSize(3);
    glBegin(GL_POINTS);
    for (int i = 0; i < points; ++i)
    {
        // std::cout << B.row(i) << std::endl;
        glVertex2f(B(i, 0), B(i, 1));
    }
    glEnd();
    glFlush();
}

void displayS(int points, arma::frowvec p1, arma::frowvec p2, arma::frowvec p3, arma::frowvec p4)
{
    arma::fmat S(points, 3);
    float inc = 0.5 / points;
    int index = 0;
    for (float s = 0.5; s <= 1 && index < points; s += inc)
        S.row(index++) = arma::frowvec({s * s, s, 1.0});
    arma::fmat N({{2, -4, 2}, {-3, 4, -1}, {1, 0, 0}});
    arma::fmat P = arma::join_cols(p2, p3, p4);
    arma::fmat B = S * N * P;

    glColor3f(0, 0, 1);
    glPointSize(3);
    glBegin(GL_POINTS);
    for (int i = 0; i < points; ++i)
    {
        // std::cout << B.row(i) << std::endl;
        glVertex2f(B(i, 0), B(i, 1));
    }
    glEnd();
    glFlush();
}

void display()
{
    auto p1 = arma::frowvec({-1, 1});
    auto p2 = arma::frowvec({0, 0.5});
    auto p3 = arma::frowvec({0.5, 0});
    auto p4 = arma::frowvec({-0.5, 0});

    glClear(GL_COLOR_BUFFER_BIT);

    int points = 1000;
    displayR(points, p1, p2, p3, p4);
    displayC(points, p1, p2, p3, p4);
    displayS(points, p1, p2, p3, p4);
}

int main(int argc, char **argv)

{
    // std::cout << R.size();
    glutInit(&argc, argv);
    glutCreateWindow("Rotate");
    glutDisplayFunc(display);
    glutMainLoop();
}